namespace TransactEase.Core.Models;

public record CountryOrRegion
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required int NumericCode { get; init; }
    public required string Alpha3Code { get; init; }
    public required string Alpha2Code { get; init; }
    public required string LocalCode { get; init; }
}