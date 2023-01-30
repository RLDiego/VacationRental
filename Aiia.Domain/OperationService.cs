using Aiia.Contracts;
using Aiia.Contracts.Entities;
using Aiia.Contracts.Entities.ap;
using Aiia.Contracts.Entities.autho;
using Aiia.Contracts.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Amount = Aiia.Contracts.Entities.Amount;
using Destination = Aiia.Contracts.Entities.Destination;
using Request = Aiia.Contracts.Entities.Request;

namespace Aiia.FrontEnd.Data;

public class OperationService
{
    private readonly IMemoryCache _memoryCache;
    public readonly ITokenRepository _tokenRepository;
    public readonly ITransactionsRepository _transactionsRepository;
    private readonly AiiaConfig _aiiaConfig;

    public OperationService(IMemoryCache memoryCache, ITokenRepository tokenRepository, ITransactionsRepository transactionsRepository, IOptions<AiiaConfig> options)
    {
        _memoryCache = memoryCache;
        _tokenRepository = tokenRepository;
        _transactionsRepository = transactionsRepository;
        _aiiaConfig = options.Value;
    }
    public async Task<TransactionsPage> GetTransactions(string paginationToken = null)
    {
        var token = await _tokenRepository.GetToken();
        var transactionsPage = (await _transactionsRepository.GetTransactions(token, this.GetAccountId(), paginationToken));
        return transactionsPage;
    }

    public async Task<PaymentsAuthStatus> GetPaymentAuthInfo()
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
        var account = GetAccountId();
        var payment = new PaymentDto()
        {
            request = new Request()
            {
                paymentMethod = "Domestic",
                sourceAccountId = account,
                transactionText = paymentData.Message,
                destination = new Destination()
                {
                    name = paymentData.NameSurname,
                    bban = new Iban()
                    {
                        accountNumber = paymentData.AccountNumber,
                        bankCode = "1234"
                    }
                },
                amount = new Amount()
                {
                    value = (double)paymentData.Ammount,
                    currency = "DKK"
                },
                execution = new Execution()
                {
                    type = "Normal"
                },
            }
        };
        return  await _transactionsRepository.CreatePayment(token, account, payment);
    }

    public async Task<string> CreateAcceptPayment(PaymentInputDto piDto)
    {
        var account = GetAccountId();
        var apInputDto = new AcceptPaymentInputDto()
        {
            redirectUrl = _aiiaConfig.AcceptPaymentCallback,
            request = new Contracts.Entities.ap.Request()
            {
                amount = new Contracts.Entities.ap.Amount()
                {
                    currency = "DKK",
                    value = piDto.Ammount.ToString()
                },
                destination = new Contracts.Entities.ap.Destination()
                {
                    bban = new Bban()
                    {
                        accountNumber = piDto.AccountNumber,
                        bankCode = "1234"
                    },
                    name = piDto.NameSurname
                }
            },
            userHash = Guid.NewGuid().ToString(),
            issuePayerToken = true
        };
        var result = await _transactionsRepository.CreateAcceptPayment(apInputDto);
        SaveAcceptPaymentId(result.paymentId);
        return result.redirectUrl;
    }

    public async Task<string> GetAcceptPaymentStatus()
    {
        return await _transactionsRepository.GetAcceptPaymentStatus(GetAcceptPaymentId());
    }
    private string GetAcceptPaymentId()
    {
        _memoryCache.TryGetValue(Constants.AcceptPayment, out string acceptPaymentId);
        return  acceptPaymentId;
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

    private void SaveAcceptPaymentId(string paymentId)
    {
        _memoryCache.Remove(Constants.AcceptPayment);
        _memoryCache.CreateEntry(Constants.AcceptPayment);
        _memoryCache.Set(Constants.AcceptPayment, paymentId, TimeSpan.FromMinutes(180));
    }
}