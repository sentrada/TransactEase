using RestSharp;
using TransactEase.Infrastructure.Interfaces.Communications;

namespace TransactEase.Infrastructure.Services.Communications;

public class RestSharpHttpClientAdapter : IHttpClientAdapter
{
    private readonly RestClient _client;

    public RestSharpHttpClientAdapter()
    {
        _client = new RestClient();
    }

    public async Task<byte[]> GetAsync(string url)
    {
        var request = new RestRequest(url, Method.Get);
        var response = await _client.ExecuteAsync(request);
        return response.RawBytes;
    }
}