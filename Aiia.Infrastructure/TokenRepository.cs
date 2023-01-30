using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;
using Aiia.Contracts.Interfaces;
using Aiia.Contracts;
using Aiia.Contracts.Entities;
using Microsoft.Extensions.Options;

namespace Aiia.Infrastructure;

    public class TokenRepository: ITokenRepository
    {
        private readonly IHttpUtils _httpUtils;
        private readonly AiiaConfig _aiiaConfig;

        public TokenRepository(IHttpUtils httpUtils, IOptions<AiiaConfig> options)
        {
            _httpUtils = httpUtils;
            _aiiaConfig = options.Value;
        }
        
        public async Task<string> GetToken()
        {
            return await File.ReadAllTextAsync(Constants.TokenPath);
        } 
        
        public async Task DeleteToken()
        {
            File.Delete(Constants.TokenPath);
        }

        public async Task<bool> Exists()
        {
            return File.Exists(Constants.TokenPath);
        }

        public async Task SaveToken(string token)
        {
            var tokenExchange = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.TokenExchange}";
            var headers = new Dictionary<string, string>();
            headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
            headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
            var content = JsonSerializer.Serialize(
                new TokenExchangeInputDto()
                {
                    Code = token,
                }
            );
            
            var result = await _httpUtils.PostFromUrl(headers, tokenExchange, content);
            var tokenResponse = JsonSerializer.Deserialize<TokenExchangeDto>(result);
            
            File.CreateText(Constants.TokenPath);
            if (tokenResponse == null) throw new Exception();
            await File.WriteAllTextAsync(Constants.TokenPath, tokenResponse.session.accessToken);
        }

        public async Task<string> GetLoginUrl()
        {
            var transactionsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.Connection}";
            var headers = new Dictionary<string, string>();
            headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
            headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
            var content = JsonSerializer.Serialize( new InitLoginDto(_aiiaConfig.LoginCallback));
        
            var result = await _httpUtils.PostFromUrl(headers, transactionsUrl, content);

            return (string)JsonNode.Parse(result)["authUrl"];
        }
    }
