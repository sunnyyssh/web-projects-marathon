using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Options;
using ThoughtSharing.Model;

namespace ThoughtSharing.Website.Model;

public class ThoughtApiClient
{
    private readonly HttpClient _httpClient;

    private readonly ThoughtApiOptions _options;

    public ThoughtApiClient(HttpClient httpClient, IOptions<ThoughtApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<Thought[]> GetThoughtsAsync()
    {
        return await _httpClient.GetFromJsonAsync<Thought[]>(_options.BaseUrl + "api/thoughts")
            ?? throw new InvalidOperationException("Cannot deserialize a response");
    }

    public async Task<Thought?> GetThoughtAsync(long id)
    {
        var response = await _httpClient.GetAsync(_options.BaseUrl + $"api/thoughts/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Thought>();
    }

    public async Task<bool> CreateThoughtAsync(Thought thought)
    {
        var response = await _httpClient.PostAsJsonAsync(_options.BaseUrl + "api/thoughts/create", thought);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateThoughtAsync(Thought thought)
    {
        var response = await _httpClient.PutAsJsonAsync(_options.BaseUrl + "api/thoughts/update", thought);
        return response.IsSuccessStatusCode;
    }
}