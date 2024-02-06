namespace TransactEase.Core.Models;

public record Bank
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Bic { get; init; }
    public string? BankCode { get; init; }
}