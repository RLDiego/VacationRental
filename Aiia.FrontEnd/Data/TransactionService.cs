using Aiia.Contracts.Entities;
using Aiia.Contracts.Interfaces;

namespace Aiia.FrontEnd.Data
{
    public class TransactionService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenRepository _tokenRepository;
        public TransactionService(IAccountRepository accountRepository, ITokenRepository tokenRepository)
        {
            _accountRepository = accountRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<List<Account>> GetAccounts()
        {
            var token = await _tokenRepository.GetToken();
            var accounts = (await _accountRepository.GetAccounts(token));
            return accounts;
        }
    }
}