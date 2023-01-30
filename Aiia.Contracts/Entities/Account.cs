// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Account
{
    public string id { get; set; }
    public string idSchema { get; set; }
    public string providerId { get; set; }
    public string name { get; set; }
    public string owner { get; set; }
    public Number number { get; set; }
    public BookedBalance bookedBalance { get; set; }
    public AvailableBalance availableBalance { get; set; }
    public string type { get; set; }
    public Features features { get; set; }
    public object topUpInformation { get; set; }
    public object pendingAmount { get; set; }
    public object creditLimit { get; set; }
}

public class AvailableBalance
{
    public double value { get; set; }
    public string currency { get; set; }
}

public class BbanParsed
{
    public string bankCode { get; set; }
    public string accountNumber { get; set; }
}

public class BookedBalance
{
    public double value { get; set; }
    public string currency { get; set; }
}

public class Features
{
    public bool queryable { get; set; }
    public bool psdPaymentAccount { get; set; }
    public bool paymentFrom { get; set; }
    public bool paymentTo { get; set; }
}

public class Number
{
    public string bbanType { get; set; }
    public string bban { get; set; }
    public string iban { get; set; }
    public object card { get; set; }
    public BbanParsed bbanParsed { get; set; }
}

public class Root
{
    public List<Account> accounts { get; set; }
    public object pagingToken { get; set; }
}