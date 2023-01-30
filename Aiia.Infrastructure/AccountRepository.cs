using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Aiia.Contracts;
using Aiia.Contracts.Entities;
using Aiia.Contracts.Interfaces;
using Microsoft.Extensions.Options;

namespace Aiia.Infrastructure;

public class AccountRepository : IAccountRepository
{
    private readonly AiiaConfig _aiiaConfig;
    private readonly IHttpUtils _httpUtils;

    public AccountRepository (IOptions<AiiaConfig> options, IHttpUtils httpUtils)
    {
        _aiiaConfig = options.Value;
        _httpUtils = httpUtils;
    }

    public async Task<List<Account>> GetAccounts(string token)
    {
        var accountsUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.GetAccounts}";
        var headers = new Dictionary<string, string>();
        headers.Add("X-Client-Id", _aiiaConfig.AiiaClientId);
        headers.Add("X-Client-Secret", _aiiaConfig.AiiaApiKey);
        
        var result = await _httpUtils.GetFromUrl(headers,accountsUrl, token);
        var accountList = JsonSerializer.Deserialize<Root>(result);
        return accountList.accounts;
    }

    public async Task<Account> GetAccount(string token, string accountId)
    {
        var accountUrl = $"{_aiiaConfig.AiiaUrl}{_aiiaConfig.AiiaEndpoints.GetAccount}{accountId}";
        var result = await _httpUtils.GetFromUrl(token, accountUrl);
        return new Account();
    }
}