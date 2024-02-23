using System.ComponentModel.DataAnnotations;

namespace TransactEase.Core.Models;

public record BranchOffice
{
    public Guid Id { get; init; } = Guid.Empty;
    public required string BranchCode { get; init; }

    [StringLength(11, MinimumLength = 8)] public required string BicCode { get; init; }

    [StringLength(250)] public required string Name { get; init; }

    public required string Address { get; init; }

    public char CanSendViber { get; init; }

    public char CanReceiveViber { get; init; }
}