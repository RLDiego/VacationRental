using Aiia.Contracts.Entities;
using Aiia.Contracts.Interfaces;

namespace Aiia.FrontEnd.Data
{
    public class AccountsService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenRepository _tokenRepository;
        public AccountsService(IAccountRepository accountRepository, ITokenRepository tokenRepository)
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