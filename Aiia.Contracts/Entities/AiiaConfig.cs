namespace Aiia.Contracts.Entities;

public class AiiaConfig
{
    public string AiiaApiKey { get; set; }
    public string AiiaClientId { get; set; }
    public string AiiaUrl { get; set; }
    public string AiiaScope { get; set; }
    public AiiaEndpoints AiiaEndpoints { get; set; }
    public string LoginCallback { get; set; }
    public string PaymentCallback { get; set; }
    public string AcceptPaymentCallback { get; set; }
}


