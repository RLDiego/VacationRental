namespace Aiia.Contracts.Entities;

public class AmountAuth
{
    public string currency { get; set; }
    public double value { get; set; }
}

public class BbannAuth
{
    public string accountNumber { get; set; }
    public string bankCode { get; set; }
}

public class DestinationAuth
{
    public BbannAuth bban { get; set; }
    public object iban { get; set; }
    public string name { get; set; }
    public object inpaymentForm { get; set; }
    public object address { get; set; }
}

public class ExecutionOptionsAuth
{
    public string type { get; set; }
    public object date { get; set; }
}

public class IdentifiersAuth
{
    public object creditorReference { get; set; }
    public object endToEndId { get; set; }
    public object finnishArchiveId { get; set; }
    public object finnishReference { get; set; }
    public object norwegianKid { get; set; }
    public object ocr { get; set; }
}

public class PaymentStatus
{
    public AmountAuth amount { get; set; }
    public string createdAt { get; set; }
    public DestinationAuth destination { get; set; }
    public ExecutionOptionsAuth executionOptions { get; set; }
    public string id { get; set; }
    public IdentifiersAuth identifiers { get; set; }
    public string message { get; set; }
    public string paymentMethod { get; set; }
    public StatusAuth status { get; set; }
}

public class PaymentStatusAuth
{
    public List<PaymentStatus> payments { get; set; }
    public object pagingToken { get; set; }
}

public class StatusAuth
{
    public string paymentStatusCode { get; set; }
    public bool terminal { get; set; }
}

