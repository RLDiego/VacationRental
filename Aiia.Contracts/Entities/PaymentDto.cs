namespace Aiia.Contracts.Entities;

public class Amount
{
    public int value { get; set; }
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

public class Payment
{
    public Amount amount { get; set; }
    public Destination destination { get; set; }
    public string message { get; set; }
    public string transactionText { get; set; }
}

public class PaymentDto
{
    public Payment payment { get; set; }
    public string redirectUrl { get; set; }
}