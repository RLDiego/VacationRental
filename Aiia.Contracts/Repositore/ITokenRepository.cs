namespace Aiia.Contracts.Interfaces;

public interface ITokenRepository
{
    Task SaveToken(string token);
    Task<string> GetToken();
    Task DeleteToken();
    Task<bool> Exists();
    Task<string> GetLoginUrl();
}