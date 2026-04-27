namespace RSSFeedReader.Api.Models;

public sealed class Subscription
{
    public string Url { get; set; } = string.Empty;
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}
