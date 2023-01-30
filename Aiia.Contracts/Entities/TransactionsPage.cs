using System.Text.Json.Serialization;

namespace Aiia.Contracts.Entities;

public class AmountT
{
    public double value { get; set; }
    public string currency { get; set; }
}

public class Balance
{
    public double value { get; set; }
    public string currency { get; set; }
}

public class TransactionsPage
{
    public List<Transaction> transactions { get; set; }
    public string pagingToken { get; set; }
    public string ordering { get; set; }
}

public class Transaction
{
    public string id { get; set; }
    public string idSchema { get; set; }
    public string date { get; set; }
    public object creationTime { get; set; }
    public string text { get; set; }
    public string originalText { get; set; }
    public object details { get; set; }
    public object category { get; set; }
    public AmountT amount { get; set; }
    public Balance balance { get; set; }
    public string type { get; set; }
    public string state { get; set; }
}



