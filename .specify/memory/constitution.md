<!--
Sync Impact Report
Version change: TEMPLATE → 1.0.0
Modified principles: none (initial constitution)
Added sections: Technology & Architecture Constraints; Development Workflow
Removed sections: none
Templates reviewed: .specify/templates/plan-template.md, .specify/templates/spec-template.md, .specify/templates/tasks-template.md
Follow-up TODOs: none
-->

# RSSFeedReader Constitution

## Core Principles

### I. Security-first minimal surface
All user input is treated as untrusted and handled explicitly. For MVP, do not add feed fetching, parsing, or persistence until the project has a clearly defined Extended-MVP scope. CORS and frontend/backend origins must be configured explicitly, and the app must not expose open cross-origin access by default.

### II. Maintainable simplicity
Implement the smallest complete solution that satisfies MVP behavior. Remove or avoid boilerplate template artifacts before writing feature code. Keep the subscription management flow modular so future persistence, refresh, and item display layers can be added without rewriting the core model.

### III. Code quality by default
Everyone writes code that is easy to read, review, and extend. Every change must compile cleanly, avoid hacks, and favor explicit behavior over clever shortcuts. Documentation, naming, and structure must make the app easy to understand for a future contributor.

### IV. Testable incrementally
Build and verify functionality in small, independent slices. Each feature increment must have a clear acceptance criterion or verification step, and the team should be able to confirm behavior before moving to the next scope.

### V. MVP discipline
The MVP is strictly the subscription list experience: add a feed URL and display subscriptions in the UI. Anything outside that scope is deferred to Extended-MVP or future work. Scope changes require explicit review and a documented decision.

## Technology & Architecture Constraints

- Use ASP.NET Core Web API for backend responsibilities and Blazor WebAssembly for the frontend user interface.
- For MVP, store subscriptions in memory only and avoid database persistence until Extended-MVP is approved.
- Do not introduce feed-fetching or XML/Atom parsing libraries until subscription management is stable and the feature scope explicitly expands.
- Ensure the frontend and backend ports are coordinated in launch settings, appsettings, and CORS configuration.
- Remove all unused Blazor demo pages and navigation routes before implementing MVP features to avoid ambiguous routing and runtime failures.

## Development Workflow

- Use feature branches for all work and reference the constitution in PR descriptions.
- All code changes must be reviewed by at least one other team member before merging.
- Every PR must verify the app still builds and runs locally, with no new compiler warnings in the changed area.
- Project reviews must confirm compliance with MVP scope, security handling, and maintainability expectations before accepting changes.
- Document any scope or architecture decisions in feature plans and stakeholder-facing artifacts.

## Governance

This constitution defines the mandatory norms for RSSFeedReader development. It supersedes informal preferences or undocumented habits.

- Amendments must be proposed in a PR, reviewed by at least one collaborator, and documented in the PR summary.
- Versioning follows semantic practices:
  - MAJOR when a principle or governance rule is removed or redefined.
  - MINOR when a new principle, section, or explicit workflow requirement is added.
  - PATCH for clarifications, wording improvements, or non-substantive refinements.
- Every feature plan and task checklist should reference this constitution and the current version.
- Compliance is expected for all MVP and Extended-MVP work; deviations require documented rationale and explicit approval.

**Version**: 1.0.0 | **Ratified**: 2026-04-27 | **Last Amended**: 2026-04-27
