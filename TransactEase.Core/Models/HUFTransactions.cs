using System.Globalization;
using System.Xml.Serialization;
using TransactEase.Core.ValueObjects;

namespace TransactEase.Core.Models;

[XmlRoot("HUFTransactions")]
public class HufTransactions
{
    private DateTime? _creationDateAndTime;
    private DateOnly? _scheduledDate;

    [XmlAttribute("version")]
    public string Version { get; set; } = "1.01";

    [XmlElement("CreationDateAndTime")]
    public string? CreationDateAndTime
    {
        get => _creationDateAndTime?.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        set => _creationDateAndTime = value == null ? null : DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
    }

    [XmlElement("ScheduledDate")]
    public string? ScheduledDate
    {
        get => _scheduledDate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        set => _scheduledDate = value == null ? null : DateOnly.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    [XmlElement("Transaction")]
    public List<Transaction> Transactions { get; set; } = [];
}

public class Transaction
{
    [XmlElement("Originator")]
    public required Originator Originator { get; set; } 

    [XmlElement("Beneficiary")]
    public required Beneficiary Beneficiary { get; set; }

    [XmlElement("Amount")]
    public required Amount Amount { get; set; } 

    private DateOnly? _requestedExecutionDate;
    [XmlElement("RequestedExecutionDate")]
    public string? RequestedExecutionDate
    {
        get => _requestedExecutionDate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        set => _requestedExecutionDate = string.IsNullOrWhiteSpace(value) ? null : DateOnly.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    [XmlElement("RemittanceInfo")]
    public RemittanceInfo? RemittanceInfo { get; set; } 

    [XmlElement("CustomerSpecifiedReference")]
    public string? CustomerSpecifiedReference { get; set; } 

    [XmlElement("StatisticalInfo")]
    public StatisticalInfo? StatisticalInfo { get; set; }

    [XmlAttribute("ProcessingMode")]
    public ProcessingMode ProcessingMode { get; set; }
}

public class Originator
{
    [XmlElement("Name")]
    public string? Name { get; set; }

    [XmlElement("Account")]
    public required Account Account { get; set; }
}

public class Beneficiary
{
    [XmlElement("Name")]
    public required string Name { get; set; }

    [XmlElement("CountryOfRegistration")]
    public CountryOfRegistration? CountryOfRegistration { get; set; }

    [XmlElement("Account")]
    public required Account Account { get; set; }
}

public class Amount
{
    [XmlAttribute("Currency")] public string Currency => "HUF";

    [XmlText]
    public required decimal Value { get; set; }
}

public class Account
{
    [XmlElement("AccountNumber")]
    public required AccountNumber AccountNumber { get; set; }
}

public class AccountNumber
{
    [XmlAttribute("Type")]
    public AccountType Type { get; set; }

    [XmlText]
    public required string Number { get; set; }
}

public class CountryOfRegistration
{
    [XmlElement("CountryCode")]
    public string? CountryCode { get; set; }

    [XmlElement("Country")]
    public string? Country { get; set; }
}

public class RemittanceInfo
{
    [XmlElement("Text")]
    public List<string> Texts { get; set; } = [];
}

public class StatisticalInfo
{
    [XmlElement("StatisticalCode")]
    public required string StatisticalCode { get; set; }
}