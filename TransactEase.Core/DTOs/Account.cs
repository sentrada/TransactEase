using TransactEase.Core.ValueObjects;

namespace TransactEase.Core.DTOs;

public class Account
{
    public string AccountNumber { get; set; }
    public AccountType Type { get; set; }
}