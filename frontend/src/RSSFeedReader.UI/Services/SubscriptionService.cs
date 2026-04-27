using System.Net.Http.Json;

namespace RSSFeedReader.UI.Services;

public sealed class Subscription
{
    public string Url { get; set; } = string.Empty;
}

public sealed class SubscriptionService
{
    private readonly HttpClient _http;

    public SubscriptionService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Subscription>> GetSubscriptionsAsync()
    {
        var subscriptions = await _http.GetFromJsonAsync<List<Subscription>>("subscriptions");
        return subscriptions ?? new List<Subscription>();
    }

    public async Task<(bool Success, string? Error)> AddSubscriptionAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return (false, "A feed URL is required.");
        }

        var response = await _http.PostAsJsonAsync("subscriptions", new { url = url.Trim() });

        if (response.IsSuccessStatusCode)
        {
            return (true, null);
        }

        var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
        return (false, errorResponse?.Error ?? "Failed to add subscription.");
    }

    private sealed class ErrorResponse
    {
        public string? Error { get; set; }
    }
}
