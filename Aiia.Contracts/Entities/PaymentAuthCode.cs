namespace Aiia.Contracts.Entities.Payment;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Amount
    {
        public double value { get; set; }
        public string currency { get; set; }
    }

    public class Destination
    {
        public object bban { get; set; }
        public Iban iban { get; set; }
        public object ownAccount { get; set; }
        public object inpaymentForm { get; set; }
        public string name { get; set; }
        public object address { get; set; }
    }

    public class Execution
    {
        public string type { get; set; }
        public object date { get; set; }
        public string fee { get; set; }
        public object feeAmount { get; set; }
    }

    public class Iban
    {
        public string ibanNumber { get; set; }
    }

    public class Identifiers
    {
    }

    public class Payment
    {
        public string paymentId { get; set; }
        public object userHash { get; set; }
        public object providerId { get; set; }
        public object providerPaymentId { get; set; }
        public Request request { get; set; }
        public Status status { get; set; }
        public DateTime created { get; set; }
        public object source { get; set; }
        public Execution execution { get; set; }
        public object message { get; set; }
        public string transactionText { get; set; }
        public Identifiers identifiers { get; set; }
    }

    public class Request
    {
        public string sourceAccountId { get; set; }
        public Destination destination { get; set; }
        public Amount amount { get; set; }
        public Execution execution { get; set; }
        public object message { get; set; }
        public string transactionText { get; set; }
        public object identifiers { get; set; }
        public string paymentMethod { get; set; }
    }

    public class Roott
    {
        public Payment payment { get; set; }
    }

    public class Status
    {
        public bool terminal { get; set; }
        public string code { get; set; }
        public DateTime lastUpdated { get; set; }
        public object details { get; set; }
    }

