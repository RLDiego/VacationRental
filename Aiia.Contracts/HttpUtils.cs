using System.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Aiia.Contracts.Interfaces;

namespace Aiia.Contracts;

public class HttpUtils : IHttpUtils
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpUtils(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public  async Task<string> GetFromUrl(string token, string url, string authType = Constants.Bearer)
    {
        using var client = _httpClientFactory.CreateClient();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authType, HttpUtility.UrlDecode(token));
        using var result = await client.SendAsync(requestMessage);
        if (result.IsSuccessStatusCode)
            return await result.Content.ReadAsStringAsync();
        
        throw new Exception();
    }
    public  async Task<string> PostFromUrl(string token, string url, string content, string authType = Constants.Bearer)
    {
        using var client = _httpClientFactory.CreateClient();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authType, token);
        requestMessage.Content = new StringContent( content, Encoding.UTF8, "application/json");
        using var result = await client.SendAsync(requestMessage);
        if (result.IsSuccessStatusCode)
            return await result.Content.ReadAsStringAsync();
        
        throw new Exception();
    }
}