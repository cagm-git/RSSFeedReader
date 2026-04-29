# RSSFeedReader Test Suite

## Overview
This suite contains API client tests located in `tests/api/` (using Playwright) and backend xUnit tests located in `tests/RSSFeedReader.Api.Tests/`.

## Setup
1. Ensure Node.js (LTS) is installed.
2. Run `npm install` in the root directory to install Playwright dependencies.
3. Ensure the backend API is running (default: `http://localhost:5000`).

## Running API Tests
- **All tests**: `npm run test:api`
- **UI Mode**: `npm run test:api:ui`
- **Debug**: `npm run test:api:debug`

## Architecture
- **Fixtures**: Located in `tests/api/support/fixtures/`.
- **Helpers**: Located in `tests/api/support/helpers/`.
- **Factories**: Located in `tests/api/support/fixtures/factories/`.

## CI Integration
API tests are configured to run as part of the quality gate in CI using the `test:api` script.
