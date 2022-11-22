using System.Text.Json.Serialization;

namespace Aiia.Contracts.Entities;

public class TokenExchangeDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    [JsonPropertyName("redirect_uri")]
    public string RedirectUrl { get; set; }
    
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
    
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
}