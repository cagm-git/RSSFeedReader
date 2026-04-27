# Research: MVP RSS Reader

## Decision
Choose an ASP.NET Core Web API backend paired with a Blazor WebAssembly frontend for the MVP. The backend will expose a minimal subscription management API, while the frontend will provide a simple UI for adding and displaying feed URLs.

## Rationale
- The stakeholder documents explicitly describe ASP.NET Core and Blazor in the technology stack.
- The MVP scope is intentionally small: add a feed URL and display subscriptions. A two-part web app supports that scope cleanly.
- An in-memory subscription store is the safest and simplest implementation for MVP, satisfying the requirement that data is lost when the app closes.
- Deferring feed fetching, parsing, and persistence avoids unnecessary complexity and keeps the initial implementation aligned with the constitution.

## Alternatives considered
- Single-page desktop or Electron app: rejected because the tech stack calls for ASP.NET Core + Blazor, and web development best matches the stakeholder strategy.
- Blazor Server instead of Blazor WebAssembly: rejected because WebAssembly better isolates the frontend and matches the stated separation of concerns.
- Adding `System.ServiceModel.Syndication` and feed parsing in MVP: rejected because the MVP must remain subscription management only.
- Using a database or local persistence: rejected because MVP is explicitly in-memory only and persistence is deferred to Extended-MVP.
