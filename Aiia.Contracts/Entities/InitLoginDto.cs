namespace Aiia.Contracts.Entities;

public class InitLoginDto
{
    public InitLoginDto(string redirectUrl)
    {
        this.redirectUrl = redirectUrl;
        this.userHash = "9077a54854311ad32ae36f1803187289";
    }
    public string userHash { get;}
    public string redirectUrl { get;}
}