namespace Aiia.Contracts.Entities.autho;

public class Details
{
    public object providerMessage { get; set; }
    public string errorType { get; set; }
    public object errorCode { get; set; }
}

public class PaymentsAuthStatus
{
    public string id { get; set; }
    public List<string> paymentIds { get; set; }
    public Status status { get; set; }
    public DateTime created { get; set; }
    public object providerAuthorizationId { get; set; }
    public string providerId { get; set; }
    public TotalAmount totalAmount { get; set; }
    public string userHash { get; set; }
    public object additionalApprovals { get; set; }
}

public class Status
{
    public bool terminal { get; set; }
    public string code { get; set; }
    public DateTime lastUpdated { get; set; }
    public Details details { get; set; }
}

public class TotalAmount
{
    public double value { get; set; }
    public string currency { get; set; }
}

