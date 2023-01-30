using System.Text.Json.Serialization;

namespace Aiia.Contracts.Entities;


public class Login
{
    public string providerId { get; set; }
    public DateTime expires { get; set; }
    public string loginToken { get; set; }
    public bool supportsUnattended { get; set; }
    public string label { get; set; }
    public string subjectId { get; set; }
    public DateTime aisScaExpires { get; set; }
}

public class TokenExchangeDto
{
    public Session session { get; set; }
    public Login login { get; set; }
    public string providerId { get; set; }
    public object state { get; set; }
}

public class Session
{
    public DateTime expires { get; set; }
    public string accessToken { get; set; }
    public List<string> scopes { get; set; }
}

