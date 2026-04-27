using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionStore _store;

    public SubscriptionsController(SubscriptionStore store)
    {
        _store = store;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_store.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] SubscriptionCreateRequest request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Url))
        {
            return BadRequest(new { error = "A non-empty URL is required." });
        }

        var added = _store.Add(request.Url);

        if (!added)
        {
            return Conflict(new { error = "Subscription already exists or URL is invalid." });
        }

        return CreatedAtAction(nameof(Get), new { }, new { url = request.Url.Trim() });
    }
}

public sealed class SubscriptionCreateRequest
{
    public string Url { get; set; } = string.Empty;
}
