namespace Aiia.Contracts.Entities;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Account
    {
        public AccountProvider accountProvider { get; set; }
        public Available available { get; set; }
        public double availableBalance { get; set; }
        public Booked booked { get; set; }
        public double bookedBalance { get; set; }
        public string currency { get; set; }
        public Features features { get; set; }
        public string id { get; set; }
        public bool isOrphaned { get; set; }
        public string lastSynchronized { get; set; }
        public string name { get; set; }
        public Number number { get; set; }
        public string owner { get; set; }
        public string syncStatus { get; set; }
        public string type { get; set; }
        public bool verifiedForPayments { get; set; }
        public object groupId { get; set; }
        public object groupName { get; set; }
    }

    public class AccountProvider
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Available
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class BbanParsed
    {
        public string accountNumber { get; set; }
        public string bankCode { get; set; }
    }

    public class Booked
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Features
    {
        public bool paymentFrom { get; set; }
        public bool paymentTo { get; set; }
        public bool psdPaymentAccount { get; set; }
        public bool queryable { get; set; }
    }

    public class Number
    {
        public string bban { get; set; }
        public BbanParsed bbanParsed { get; set; }
        public string bbanType { get; set; }
        public object card { get; set; }
        public string iban { get; set; }
    }

    public class Root
    {
        public List<Account> accounts { get; set; }
    }

