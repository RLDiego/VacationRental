namespace Aiia.Contracts.Entities.ap;

public class Amount
{
    public string value { get; set; }
    public string currency { get; set; }
}

public class Bban
{
    public string bankCode { get; set; }
    public string accountNumber { get; set; }
}

public class Destination
{
    public Bban bban { get; set; }
    public string name { get; set; }
}

public class Request
{
    public Destination destination { get; set; }
    public Amount amount { get; set; }
}

public class AcceptPaymentInputDto
{
    public string userHash { get; set; }
    public Request request { get; set; }
    public bool issuePayerToken { get; set; }
    public string redirectUrl { get; set; }
}

