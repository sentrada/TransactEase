using System.ComponentModel.DataAnnotations;
using TransactEase.ExcelImporter.Attributes;

namespace TransactEase.ExcelImporter.DTOs;

public class BranchOfficeDto
{
    public Guid Id { get; set; } = Guid.Empty;
    [ExcelColumn("Branch office code")] public string BranchCode { get; set; } = null!;

    [StringLength(11, MinimumLength = 8)]
    [ExcelColumn("BIC code")]
    public string BicCode { get; set; } = null!;

    [StringLength(250)]
    [ExcelColumn("Name of the branch office")]
    public string Name { get; set; } = null!;

    [ExcelColumn("Address of the branch office")]
    public string Address { get; set; } = null!;

    [ExcelColumn("Branch office may send VIBER items")]
    public char CanSendViber { get; set; }

    [ExcelColumn("Branch office may receive VIBER items")]
    public char CanReceiveViber { get; set; }
}