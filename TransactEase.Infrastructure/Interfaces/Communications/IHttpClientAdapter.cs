namespace TransactEase.Infrastructure.Interfaces.Communications;

public interface IHttpClientAdapter
{
    Task<byte[]> GetAsync(string url);
}