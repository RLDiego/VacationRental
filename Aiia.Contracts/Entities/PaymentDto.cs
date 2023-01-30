namespace Aiia.Contracts.Entities;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Amount
{
    public double value { get; set; }
    public string currency { get; set; }
}

public class Destination
{
    public string name { get; set; }
    public Iban bban { get; set; }
}

public class Execution
{
    public string type { get; set; }
}

public class Iban
{
    public string accountNumber { get; set; }
    public string bankCode { get; set; }
}

public class Request
{
    public string paymentMethod { get; set; }
    public string sourceAccountId { get; set; }
    public string transactionText { get; set; }
    public Destination destination { get; set; }
    public Amount amount { get; set; }
    public Execution execution { get; set; }
}

public class PaymentDto
{
    public Request request { get; set; }
}

