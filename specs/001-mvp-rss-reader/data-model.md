# Data Model: MVP RSS Reader

## Entity: Subscription

Represents a single RSS/Atom feed subscription entered by the user.

- `Url` (string): The feed URL entered by the user.
- `CreatedAt` (datetime, optional): Timestamp when the subscription was added. Useful for later sorting or auditing.

### Validation Rules
- `Url` must be non-empty.
- `Url` should be normalized for display, but the MVP does not validate feed format or reachability.
- The application may optionally prevent duplicate URLs, but duplicates are not required for MVP.

### Relationships
- None for MVP. The model is a flat list of subscriptions.

### State Transitions
- `New` → `Added`: When the user submits a subscription URL, it is added to the in-memory list.
- `Added` → `Displayed`: The subscription immediately appears in the UI list for the current session.

## In-memory collection

For MVP, the subscriptions are stored in a simple in-memory collection (e.g. `List<Subscription>` or `List<string>`). The collection is reset when the application restarts.
