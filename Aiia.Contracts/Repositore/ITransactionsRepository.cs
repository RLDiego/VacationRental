using Aiia.Contracts.Entities;
using Aiia.Contracts.Entities.ap;
using Aiia.Contracts.Entities.autho;

namespace Aiia.Contracts.Interfaces;

public interface ITransactionsRepository
{
    Task<TransactionsPage> GetTransactions(string token, string accountId, string paginationToken = null);
    Task<string> CreatePayment(string token, string accountId, PaymentDto payment);
    Task<PaymentAuthUrlDto> AuthorizePayment(string token, string paymentId, string accountId);
    Task<PaymentsAuthStatus> GetPaymentStatus(string paymentAuth, string token, string accountId);
    Task<AcceptPaymentResultDto> CreateAcceptPayment(AcceptPaymentInputDto ap);
    Task<string> GetAcceptPaymentStatus(string paymentId);
}