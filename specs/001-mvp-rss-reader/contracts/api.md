# API Contract: Subscription Management

## Base Path

`/api/subscriptions`

## GET /api/subscriptions

Returns the current list of subscriptions stored in memory for the current session.

### Request
- Method: `GET`
- URL: `/api/subscriptions`

### Response
- Status: `200 OK`
- Body: JSON array of subscription objects

Example response:

```json
[
  {
    "url": "https://example.com/feed.xml"
  }
]
```

## POST /api/subscriptions

Adds a new subscription to the in-memory list.

### Request
- Method: `POST`
- URL: `/api/subscriptions`
- Body: JSON object

Example request body:

```json
{
  "url": "https://example.com/feed.xml"
}
```

### Response
- Success: `201 Created` or `200 OK`
- Body: JSON object representing the added subscription

Example success response:

```json
{
  "url": "https://example.com/feed.xml"
}
```

### Validation
- The `url` field must be present and non-empty.
- The MVP does not validate that the URL points to an actual RSS/Atom feed.

## Frontend contract expectations

- The frontend sends a `POST` request with a single `url` property.
- The frontend fetches the current subscription list with `GET`.
- The UI displays results from the response body without requiring additional transformations.
