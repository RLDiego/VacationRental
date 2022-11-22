﻿using System.Web;
using Aiia.Contracts.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Aiia.Contracts;
using Aiia.Contracts.Interfaces;

namespace Aiia.FrontEnd.Data
{
    public class LoginService
    {

        private readonly AiiaConfig _aiiaConfig;
        public readonly ITokenRepository _tokenRepository;

        public LoginService(IOptions<AiiaConfig> options, ITokenRepository tokenRepository)
        {
            _aiiaConfig = options.Value;
            _tokenRepository = tokenRepository;
        }

        public async Task<bool> IsLoged()
        {
            return await _tokenRepository.Exists();
        }

        public async Task<bool> SignOut()
        {
            await _tokenRepository.DeleteToken();
            return false;
        }

        public async Task<string> SignInUrl()
        {
            var aiiaSignInUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.Connection}";
            return await Task.FromResult(String.Format(aiiaSignInUrl, _aiiaConfig.AiiaClientId, HttpUtility.UrlEncode(_aiiaConfig.LoginCallback)));
        }
    }
}
