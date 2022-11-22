using Aiia.Contracts.Entities;

namespace Aiia.Contracts.Interfaces;

public interface IAccountRepository
{
    Task<List<Account>> GetAccounts(string token);
      Task<Account> GetAccount(string token, string accountId);
}