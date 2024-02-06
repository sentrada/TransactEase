namespace TransactEase.Core.Models;

public record Currency
{
    public required Guid Id { get; init; }
    public required CountryOrRegion CountryOrRegion { get; init; }
    public required string CurrencyName { get; init; }
    public required string Code { get; init; }
    public required int Number { get; init; }
}