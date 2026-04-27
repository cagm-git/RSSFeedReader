# Quickstart: MVP RSS Reader

## Prerequisites

- .NET SDK 8.0 or later installed
- A code editor such as Visual Studio Code
- A modern browser for the Blazor WebAssembly frontend

## Recommended project layout

This repository currently contains documentation only. The MVP implementation should use a two-part web app structure:

```text
backend/
  src/
    RSSFeedReader.Api/  # ASP.NET Core Web API project
frontend/
  src/
    RSSFeedReader.UI/   # Blazor WebAssembly project
```

## Create the project skeleton

1. Create the backend API:

```bash
dotnet new webapi -o backend/src/RSSFeedReader.Api
```

2. Create the Blazor WebAssembly frontend:

```bash
dotnet new blazorwasm -o frontend/src/RSSFeedReader.UI
```

3. Remove or replace template demo pages from the frontend to avoid routing conflicts.

## Configure the MVP flow

1. In the backend API, implement two endpoints:
   - `GET /api/subscriptions` → returns the current subscription list
   - `POST /api/subscriptions` → accepts `{ "url": "..." }` and adds it to the list

2. In the frontend, build a simple page with:
   - an input field for the feed URL
   - a button to add the subscription
   - a list of current subscriptions displayed immediately after add

3. Ensure CORS permits the development frontend origin when calling the backend.

## Run the app

1. Start the backend API:

```bash
cd backend/src/RSSFeedReader.Api
dotnet run
```

2. Start the frontend app:

```bash
cd frontend/src/RSSFeedReader.UI
dotnet run
```

3. Open the frontend URL in the browser and verify that adding a feed URL updates the displayed subscription list.

## What to verify

- The app starts cleanly with no compiler or runtime errors.
- The subscription list updates immediately after adding a URL.
- The app does not fetch or parse feed content in MVP.
- Restarting the app clears the subscription list, confirming in-memory scope.
