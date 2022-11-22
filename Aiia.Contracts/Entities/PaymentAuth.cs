namespace Aiia.Contracts.Entities;

public class PaymentAuth
{
    public string[] paymentIds { get; set; }
    public string redirectUrl { get; set; }
}