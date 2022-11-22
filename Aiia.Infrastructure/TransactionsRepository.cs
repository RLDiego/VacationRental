using System.Text.Json;
using System.Text.Json.Nodes;
using Aiia.Contracts.Entities;
using Aiia.Contracts.Interfaces;
using Microsoft.Extensions.Options;

namespace Aiia.Infrastructure;

public class  TransactionsRepository : ITransactionsRepository
{
    private readonly AiiaConfig _aiiaConfig;
    private readonly IHttpUtils _httpUtils;

    public TransactionsRepository (IOptions<AiiaConfig> options, IHttpUtils httpUtils)
    {
        _aiiaConfig = options.Value;
        _httpUtils = httpUtils;
    }

    public async Task<TransactionsPage> GetTransactions(string token, string accountId, string paginationToken = null)
    {
        var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.GetTransactions}";
        transactionsUrl = string.Format(transactionsUrl, accountId);
        if(!string.IsNullOrWhiteSpace(paginationToken))
            transactionsUrl = $"{transactionsUrl}&pagingToken={paginationToken}";
        
        var result = await _httpUtils.GetFromUrl(token, transactionsUrl);

        var transactions = JsonSerializer.Deserialize<TransactionsPage>(result);
        return transactions;
    }
    
    public async Task<string> CreatePayment(string token, string accountId, PaymentDto payment)
    {
        var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.GetPaymentAuth}";
        transactionsUrl = string.Format(transactionsUrl, accountId);
        payment.redirectUrl = _aiiaConfig.PaymentCallback;
        var content = JsonSerializer.Serialize(payment);
        
        var result = await _httpUtils.PostFromUrl(token, transactionsUrl, content);
        return (string)JsonNode.Parse(result)["paymentId"];
    }

    public async Task<PaymentAuthUrlDto> AuthorizePayment(string token, string paymentId, string accountId)
    {
        var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.PaymentAuth}";
        transactionsUrl = string.Format(transactionsUrl, accountId);
        var content = JsonSerializer.Serialize( new PaymentAuth()
        {
            paymentIds = new string[]{paymentId},
            redirectUrl = _aiiaConfig.PaymentCallback
        });
        
        var result = await _httpUtils.PostFromUrl(token, transactionsUrl, content);

        var paymentUrl = JsonSerializer.Deserialize<PaymentAuthUrlDto>(result);
        return paymentUrl;
    }

    public async Task<PaymentStatusAuth> GetPaymentStatus(string paymentAuth, string token, string accountId)
    {
        var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.PaymentStatus}";
        transactionsUrl = string.Format(transactionsUrl, accountId, paymentAuth);

        var result = await _httpUtils.GetFromUrl(token, transactionsUrl);

        var paymentUrl = JsonSerializer.Deserialize<PaymentStatusAuth>(result);
        return paymentUrl;
    }
}