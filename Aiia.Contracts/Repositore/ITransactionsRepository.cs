using Aiia.Contracts.Entities;

namespace Aiia.Contracts.Interfaces;

public interface ITransactionsRepository
{
    Task<TransactionsPage> GetTransactions(string token, string accountId, string paginationToken = null);
    Task<string> CreatePayment(string token, string accountId, PaymentDto payment);
    Task<PaymentAuthUrlDto> AuthorizePayment(string token, string paymentId, string accountId);
    Task<PaymentStatusAuth> GetPaymentStatus(string paymentAuth, string token, string accountId);
}