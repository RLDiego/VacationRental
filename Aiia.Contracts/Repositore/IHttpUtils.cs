namespace Aiia.Contracts.Interfaces;

public interface IHttpUtils
{
    Task<string> GetFromUrl(string token, string url, string authType = Constants.Bearer);
    Task<string> PostFromUrl(string token, string url, string content, string authType = Constants.Bearer);

    Task<string> PostFromUrl(Dictionary<string, string> headers, string url, string content, string token = null);

    Task<string> GetFromUrl(Dictionary<string, string> headers, string url, string token = null);
}