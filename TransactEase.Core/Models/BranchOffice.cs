using System.ComponentModel.DataAnnotations;
using TransactEase.ExcelImporter.Attributes;


namespace TransactEase.Core.Models;

public record BranchOffice
{
    public Guid Id { get; } = Guid.Empty;
    [ExcelColumn("Branch office code")] public string BranchCode { get; }

    [StringLength(11, MinimumLength = 8)]
    [ExcelColumn("BIC code")]
    public string BicCode { get; }

    [StringLength(250)]
    [ExcelColumn("Name of the branch office")]
    public string Name { get; }

    [ExcelColumn("Address of the branch office")]
    public string Address { get; }

    [ExcelColumn("Branch office may send VIBER items")]
    public char CanSendViber { get; }

    [ExcelColumn("Branch office may receive VIBER items")]
    public char CanReceiveViber { get; }

    public BranchOffice(string branchCode, string bicCode, string name, string address, char canSendViber,
        char canReceiveViber)
    {
        BranchCode = branchCode;
        BicCode = bicCode;
        Name = name;
        Address = address;
        CanSendViber = canSendViber;
        CanReceiveViber = canReceiveViber;
    }

    public BranchOffice()
    {
    }
}