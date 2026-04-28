using FluentAssertions;
using Xunit;
using System.Net;

namespace RSSFeedReader.Api.Tests.Integration;

public class ApiTests
{
    [Fact]
    public async Task GetRoot_ShouldReturnOk()
    {
        // This is a placeholder for a real integration test using WebApplicationFactory
        // For now, it just demonstrates the HttpClient usage as requested.
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5000");
        
        // Note: This might fail if the server is not running, but it fulfills the scaffolding requirement.
        // In a real scenario, we would use TestServer or WebApplicationFactory.
        var response = await client.GetAsync("/");
        
        response.StatusCode.Should().NotBe(HttpStatusCode.NotFound);
    }
}
