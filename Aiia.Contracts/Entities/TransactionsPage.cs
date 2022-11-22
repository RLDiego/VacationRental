using System.Text.Json.Serialization;

namespace Aiia.Contracts.Entities;
    public class Balance
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Card
    {
        public string cardHolder { get; set; }
        public object expireMonth { get; set; }
        public object expireYear { get; set; }
        public string maskedPan { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public Names names { get; set; }
        public string parentId { get; set; }
        public string setId { get; set; }
        public double score { get; set; }
    }

    public class DestinationT
    {
        public object account { get; set; }
        public object address { get; set; }
        public object merchantCategoryCode { get; set; }
        public object merchantCategoryName { get; set; }
        public string name { get; set; }
    }

    public class Detail
    {
        public object currencyConversion { get; set; }
        [JsonPropertyName("destination")]

        public DestinationT destination { get; set; }
        public object executionDate { get; set; }
        public Identifiers identifiers { get; set; }
        public object message { get; set; }
        public object reward { get; set; }
        public List<object> routing { get; set; }
        public Source source { get; set; }
        public object valueDate { get; set; }
    }

    public class EstimatedBalance
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Identifiers
    {
        public object creditorReference { get; set; }
        public object document { get; set; }
        public object endToEndId { get; set; }
        public object finnishArchiveId { get; set; }
        public object finnishReference { get; set; }
        public object norwegianKid { get; set; }
        public string reference { get; set; }
        public object sequenceNumber { get; set; }
        public object terminal { get; set; }
    }

    public class Names
    {
        public string da { get; set; }
        public string en { get; set; }
        public string fi { get; set; }
        public string no { get; set; }
        public string sv { get; set; }
    }

    public class TransactionsPage
    {
        public string pagingToken { get; set; }
        public List<Transaction> transactions { get; set; }
    }

    public class Source
    {
        public Account account { get; set; }
        public object address { get; set; }
        public object merchantCategoryCode { get; set; }
        public object merchantCategoryName { get; set; }
        public object name { get; set; }
    }

    public class Transaction
    {
        public string accountId { get; set; }
        public double amount { get; set; }
        public Balance balance { get; set; }
        public List<Category> categories { get; set; }
        public DateTime creationDate { get; set; }
        public string currency { get; set; }
        public string date { get; set; }
        public Detail detail { get; set; }
        public EstimatedBalance estimatedBalance { get; set; }
        public string id { get; set; }
        public bool isDeleted { get; set; }
        public object nagApiTransactionId { get; set; }
        public string originalText { get; set; }
        public string state { get; set; }
        public string text { get; set; }
        public TransactionAmount transactionAmount { get; set; }
        public string type { get; set; }
    }

    public class TransactionAmount
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

