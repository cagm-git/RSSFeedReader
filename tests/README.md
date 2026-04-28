# Testing Strategy - RSSFeedReader

This document outlines the testing strategy, architecture, and procedures for the RSSFeedReader project. Our approach ensures high reliability and maintainability through a combination of backend unit/integration tests and end-to-end (E2E) UI tests.

## Introduction

The project employs a multi-layered testing strategy:
- **Backend Testing**: Powered by **xUnit**, focusing on business logic (Unit Tests) and API/Database interactions (Integration Tests).
- **End-to-End (E2E) Testing**: Powered by **Playwright**, validating critical user journeys across the entire stack.

## Prerequisites

To run the full test suite, ensure you have the following installed:
- **.NET 8 SDK** (for backend tests)
- **Node.js v20+** (for E2E tests)
- **Docker** (optional, but recommended for integration tests requiring a database)

## Running Backend Tests

Backend tests are located in `tests/RSSFeedReader.Api.Tests`. You can run them using the .NET CLI.

### Run All Backend Tests
```bash
dotnet test
```

### Run Specific Test Projects
```bash
# Unit Tests
dotnet test tests/RSSFeedReader.Api.Tests --filter Category=Unit

# Integration Tests
dotnet test tests/RSSFeedReader.Api.Tests --filter Category=Integration
```

## Running E2E Tests

E2E tests are located in `tests/RSSFeedReader.E2E`.

### Setup
Navigate to the E2E directory and install dependencies:
```bash
cd tests/RSSFeedReader.E2E
npm install
npx playwright install
```

### Execution Commands
```bash
# Run tests in headless mode
npm run test:e2e

# Run tests with UI Mode
npm run test:e2e:ui

# Run tests in debug mode
npm run test:e2e:debug

# View test report
npm run test:e2e:report
```

## Architecture

### E2E Test Structure
The E2E suite is designed for resilience and scalability:
- **Fixtures (`support/fixtures`)**: We use Playwright custom fixtures to encapsulate page objects and common setup logic, ensuring tests remain clean and focused.
- **Factories**: Data factories are utilized to generate consistent and valid test data for various scenarios.
- **Utilities**: We leverage `@seontechnologies/playwright-utils` for enhanced assertions, network monitoring, and common browser interactions.

## Best Practices

To maintain a high-quality test suite, we adhere to the following principles:

1. **Deterministic Tests**: Tests must be reliable and produce the same result every time. Avoid any dependency on external state that cannot be reset.
2. **Unique Data**: Use libraries like `faker` (or similar) to generate unique data for every test run, preventing collisions and ensuring independence.
3. **No Hard Waits**: Never use `page.waitForTimeout()`. Instead, rely on Playwright's built-in "auto-waiting" or explicit assertions that wait for specific UI states.
4. **Surgical Assertions**: Focus assertions on the specific outcome being tested to make failures easy to diagnose.
5. **Clean State**: Each test should ideally start with a fresh state or a known-good configuration.
