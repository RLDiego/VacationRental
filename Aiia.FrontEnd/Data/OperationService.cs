using Aiia.Contracts;
using Aiia.Contracts.Entities;
using Aiia.Contracts.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Aiia.FrontEnd.Data;

public class OperationService
{
    private readonly IMemoryCache _memoryCache;
    public readonly ITokenRepository _tokenRepository;
    public readonly ITransactionsRepository _transactionsRepository;

    public OperationService(IMemoryCache memoryCache, ITokenRepository tokenRepository, ITransactionsRepository transactionsRepository)
    {
        _memoryCache = memoryCache;
        _tokenRepository = tokenRepository;
        _transactionsRepository = transactionsRepository;
    }
    public async Task<TransactionsPage> GetTransactions(string paginationToken = null)
    {
        var token = await _tokenRepository.GetToken();
        var transactionsPage = (await _transactionsRepository.GetTransactions(token, this.GetAccountId(), paginationToken));
        return transactionsPage;
    }

    public async Task<PaymentStatusAuth> GetPaymentAuthInfo()
    {
        var result =
            await _transactionsRepository.GetPaymentStatus(GetPaymentAuth(), await _tokenRepository.GetToken(), GetAccountId());
        return result;
    }

    public async Task<string> DoPayment(PaymentInputDto payment)
    {
        var token = await _tokenRepository.GetToken();
        var paymentId = await InitializePayment(payment, token);
        var redirectUrl = await _transactionsRepository.AuthorizePayment(token, paymentId, GetAccountId());
        return redirectUrl.authorizationUrl;
    }
    
    private async Task<string> InitializePayment(PaymentInputDto paymentData, string token)
    {
        var payment = new PaymentDto()
        {
            payment = new Contracts.Entities.Payment()
        };
        payment.payment.amount = new Amount()
        {
            currency = "DKK",
            value = paymentData.Ammount
        };
        payment.payment.destination = new Destination()
        {
            name = paymentData.NameSurname,
            bban = new Bban()
            {
                accountNumber = paymentData.AccountNumber,
                bankCode = "1234"
            }
        };
        payment.payment.message = paymentData.Message;
        payment.payment.transactionText = "Invoice 2";
        _memoryCache.TryGetValue(Constants.Account, out string account);
        
        return  await _transactionsRepository.CreatePayment(token, account, payment);
    }
    
    private string GetAccountId()
    {
        _memoryCache.TryGetValue(Constants.Account, out string accountId);
        return  accountId;
    }
    
    private string GetPaymentAuth()
    {
        _memoryCache.TryGetValue(Constants.Transaction, out string accountId);
        return  accountId;
    }

}