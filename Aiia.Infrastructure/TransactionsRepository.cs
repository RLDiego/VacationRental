using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;
using Aiia.Contracts.Entities;
using Aiia.Contracts.Entities.ap;
using Aiia.Contracts.Entities.autho;
using Aiia.Contracts.Entities.Payment;
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
        
        var headers = new Dictionary<string, string>();
        headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
        headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
        
        var result = await _httpUtils.GetFromUrl(headers,transactionsUrl, token);

        var transactions = JsonSerializer.Deserialize<TransactionsPage>(result);
        return transactions;
    }
    
    public async Task<string> CreatePayment(string token, string accountId, PaymentDto payment)
    {
        var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.GetPaymentAuth}";
        transactionsUrl = string.Format(transactionsUrl, accountId);
        var content = JsonSerializer.Serialize(payment);
        var headers = new Dictionary<string, string>();
        headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
        headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
        var result = await _httpUtils.PostFromUrl(headers, transactionsUrl, content);
        var transactions = JsonSerializer.Deserialize<Roott>(result);
        return transactions.payment.paymentId;
    }

    public async Task<PaymentAuthUrlDto> AuthorizePayment(string token, string paymentId, string accountId)
    {
        var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.PaymentAuth}";
        var content = JsonSerializer.Serialize( new PaymentAuth()
        {
            paymentIds = new string[]{paymentId},
            redirectUrl = _aiiaConfig.PaymentCallback
        });
        var headers = new Dictionary<string, string>();
        headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
        headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
        var result = await _httpUtils.PostFromUrl(headers, transactionsUrl, content, token);

        var paymentUrl = JsonSerializer.Deserialize<PaymentAuthUrlDto>(result);
        return paymentUrl;
    }

    public async Task<PaymentsAuthStatus> GetPaymentStatus(string paymentAuth, string token, string accountId)
    {
        var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.PaymentStatus}";
        transactionsUrl = string.Format(transactionsUrl, paymentAuth);
        var headers = new Dictionary<string, string>();
        headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
        headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
        var result = await _httpUtils.GetFromUrl(headers, transactionsUrl);

        var paymentStatus = JsonSerializer.Deserialize<PaymentsAuthStatus>(result);
        return paymentStatus;
    }

    public async Task<AcceptPaymentResultDto> CreateAcceptPayment(AcceptPaymentInputDto ap)
    {
        var acceptPaymentUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.CreateAcceptPayment}";
        var headers = new Dictionary<string, string>();
        headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
        headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
        var content = JsonSerializer.Serialize(ap);
        var result = await _httpUtils.PostFromUrl(headers, acceptPaymentUrl, content);
        var paymentUrl = JsonSerializer.Deserialize<AcceptPaymentResultDto>(result);
        
        return paymentUrl;
    }

    public async Task<string> GetAcceptPaymentStatus(string paymentId)
    {
        var apStatus = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.AcceptPaymentStatus}";
        apStatus = string.Format(apStatus, paymentId);
        var headers = new Dictionary<string, string>();
        headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
        headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
        var result = await _httpUtils.PostFromUrl(headers, apStatus, string.Empty);
        return result;
    }
}