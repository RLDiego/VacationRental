using System.Text.Json.Serialization;

namespace Aiia.Contracts.Entities;

public class TokenExchangeInputDto
{
    
    [JsonPropertyName("code")]
    public string Code { get; set; }
    
}