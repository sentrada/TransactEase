namespace TransactEase.Core.DTOs;

public class Beneficiary
{
    public string Name { get; set; }
    public CountryOfRegistration CountryOfRegistration { get; set; }
    public Account Account { get; set; }
}