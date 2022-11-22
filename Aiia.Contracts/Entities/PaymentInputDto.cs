using Microsoft.AspNetCore.Mvc;

namespace Aiia.Contracts.Entities;

public class PaymentInputDto
{
    public string NameSurname {get; set;}
    public int Ammount {get; set;}
    public string Message {get; set;}
    public string AccountNumber {get; set;}
}