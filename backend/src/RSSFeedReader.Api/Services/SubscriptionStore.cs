using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public sealed class SubscriptionStore
{
    private readonly List<Subscription> _subscriptions = new();
    private readonly object _lock = new();

    public IEnumerable<Subscription> GetAll()
    {
        lock (_lock)
        {
            return _subscriptions.ToList();
        }
    }

    public bool Add(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        var normalizedUrl = url.Trim();

        lock (_lock)
        {
            if (_subscriptions.Any(s => string.Equals(s.Url, normalizedUrl, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            _subscriptions.Add(new Subscription
            {
                Url = normalizedUrl,
                AddedAt = DateTime.UtcNow
            });

            return true;
        }
    }
}
