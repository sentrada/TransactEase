namespace TransactEase.Core.DTOs;

public class Transaction
{
    public Originator Originator { get; set; }
    public Beneficiary Beneficiary { get; set; }
    public string Amount { get; set; }
    public string RequestedExecutionDate { get; set; }
    public RemittanceInfo RemittanceInfo { get; set; }
    public string CustomerSpecifiedReference { get; set; }
    public StatisticalInfo StatisticalInfo { get; set; }
    public string ProcessingMode { get; set; }
}