using System.Xml.Serialization;

namespace TransactEase.Core.DTOs;

[XmlRoot(ElementName = "HUFTransactions")]
public class HufTransactions
{
    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; } = "1.01";

    [XmlElement(ElementName = "CreationDateAndTime")]
    public DateTime? CreationDateAndTime { get; set; }

    [XmlElement(ElementName = "ScheduledDate")]
    public DateOnly? ScheduledDate { get; set; }

    [XmlElement(ElementName = "Transaction")]
    public List<Transaction> Transactions { get; set; } = [];
}