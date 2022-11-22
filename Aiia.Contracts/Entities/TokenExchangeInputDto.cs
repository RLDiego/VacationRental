using System.Text.Json.Serialization;

namespace Aiia.Contracts.Entities;

public class TokenExchangeInputDto
{
    [JsonPropertyName("grant_type")]
    public string GrantType { get; set;}
    [JsonPropertyName("code")]
    public string Code { get; set; }
    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; set; }
}