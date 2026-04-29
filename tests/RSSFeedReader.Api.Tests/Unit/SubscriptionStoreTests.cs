using RSSFeedReader.Api.Services;
using Xunit;
using System.Linq;

namespace RSSFeedReader.Api.Tests.Unit;

public sealed class SubscriptionStoreTests
{
    private readonly SubscriptionStore _store = new();

    [Fact]
    public void Add_ValidUrl_ReturnsTrueAndAddsToStore()
    {
        // Arrange
        var url = "https://example.com/feed.xml";

        // Act
        var result = _store.Add(url);
        var subscriptions = _store.GetAll();

        // Assert
        Assert.True(result);
        Assert.Contains(subscriptions, s => s.Url == url);
    }

    [Fact]
    public void Add_DuplicateUrl_ReturnsFalse()
    {
        // Arrange
        var url = "https://example.com/duplicate.xml";
        _store.Add(url);

        // Act
        var result = _store.Add(url);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Add_CaseInsensitiveDuplicate_ReturnsFalse()
    {
        // Arrange
        var url = "https://example.com/case.xml";
        _store.Add(url);

        // Act
        var result = _store.Add(url.ToUpperInvariant());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetAll_ReturnsAllAddedSubscriptions()
    {
        // Arrange
        _store.Add("https://url1.com");
        _store.Add("https://url2.com");

        // Act
        var subscriptions = _store.GetAll();

        // Assert
        Assert.Equal(2, subscriptions.Count());
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Add_InvalidUrl_ReturnsFalse(string? url)
    {
        // Act
        var result = _store.Add(url!);

        // Assert
        Assert.False(result);
    }
}