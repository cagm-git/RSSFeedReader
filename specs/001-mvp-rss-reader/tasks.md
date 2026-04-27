# Tasks: MVP RSS Reader

**Input**: Design documents from `/specs/001-mvp-rss-reader/`
**Prerequisites**: plan.md, spec.md, research.md, data-model.md, quickstart.md, contracts/api.md

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Initialize the web application structure and create the foundation for backend and frontend development.

- [X] T001 Create backend ASP.NET Core Web API project in `backend/src/RSSFeedReader.Api`
- [X] T002 Create frontend Blazor WebAssembly project in `frontend/src/RSSFeedReader.UI`
- [X] T003 [P] Add feature documentation files in `specs/001-mvp-rss-reader/` to preserve the MVP plan and contracts

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Implement the backend model, service, API contract, and frontend HTTP configuration that all user stories depend on.

- [X] T004 Create `backend/src/RSSFeedReader.Api/Models/Subscription.cs` to define the subscription data model
- [X] T005 [P] Create `backend/src/RSSFeedReader.Api/Services/SubscriptionStore.cs` for in-memory subscription storage
- [X] T006 [P] Configure CORS in `backend/src/RSSFeedReader.Api/Program.cs` to allow the frontend origin
- [X] T007 Implement API endpoints in `backend/src/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` for `GET /api/subscriptions` and `POST /api/subscriptions`
- [X] T008 [P] Configure frontend `frontend/src/RSSFeedReader.UI/wwwroot/appsettings.json` and `frontend/src/RSSFeedReader.UI/Program.cs` to use the backend API base URL
- [X] T009 [P] Remove or disable Blazor template demo pages in `frontend/src/RSSFeedReader.UI/Pages/` and adjust navigation links in `frontend/src/RSSFeedReader.UI/Shared/NavMenu.razor`

**Checkpoint**: The backend API and frontend app are set up and can communicate, with the shared subscription model defined.

---

## Phase 3: User Story 1 - Add and view subscriptions (Priority: P1) 🎯 MVP

**Goal**: Let the user add a feed URL and display the current list of subscriptions in the UI.

**Independent Test**: Open the frontend, enter a feed URL, submit it, and verify the URL appears immediately in the subscription list.

### Implementation for User Story 1

- [X] T010 [P] [US1] Create `frontend/src/RSSFeedReader.UI/Pages/Subscriptions.razor` for the subscription management page
- [X] T011 [P] [US1] Add a feed URL input form to `frontend/src/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T012 [P] [US1] Add a subscription list display to `frontend/src/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [X] T013 [US1] Create `frontend/src/RSSFeedReader.UI/Services/SubscriptionService.cs` to call the backend API
- [X] T014 [US1] Configure `frontend/src/RSSFeedReader.UI/App.razor` to route `/` to the subscription page
- [X] T015 [US1] Update `frontend/src/RSSFeedReader.UI/Shared/NavMenu.razor` to include navigation for the subscription page if needed
- [X] T016 [US1] Implement empty-input validation in the frontend so blank URLs are not submitted and the current list remains unchanged
- [X] T017 [US1] Implement duplicate URL guarding so resubmitting an existing subscription does not add a duplicate entry
- [X] T018 [US1] Verify manual subscription add flow in the browser and confirm the list is updated after each POST request, including invalid and duplicate cases

**Checkpoint**: User Story 1 should be fully functional; adding a URL updates the subscription list and the frontend matches the backend contract.

---

## Phase 4: Polish & Cross-Cutting Concerns

**Purpose**: Clean up documentation, validate the contract, and confirm the MVP scope is preserved.

- [ ] T019 [P] Confirm `specs/001-mvp-rss-reader/contracts/api.md` matches the implemented backend API shape
- [ ] T020 [P] Confirm the frontend uses the backend base URL from `frontend/src/RSSFeedReader.UI/wwwroot/appsettings.json`
- [ ] T021 [P] Confirm the app still builds and starts cleanly in both `backend/src/RSSFeedReader.Api` and `frontend/src/RSSFeedReader.UI`
- [ ] T022 [P] Document the MVP in `specs/001-mvp-rss-reader/quickstart.md` and preserve the in-memory scope by noting that restart clears subscriptions

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies, can begin immediately.
- **Foundational (Phase 2)**: Depends on Setup completion and blocks user stories.
- **User Story 1 (Phase 3)**: Depends on Foundational completion.
- **Polish (Phase 4)**: Depends on User Story 1 completion.

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational is complete; no dependencies on other stories.

### Parallel Opportunities

- `T003`, `T005`, `T006`, `T008`, `T009`, `T010`, `T011`, `T012`, `T013`, `T016`, `T017`, `T018`, `T019`, `T020`, `T021`, and `T022` can run in parallel when there is no direct ordering dependency.
- Backend model and service setup can happen in parallel with frontend HTTP configuration once the project scaffold is available.
- UI component and routing work can happen in parallel with backend endpoint implementation after the shared model is defined.

## Implementation Strategy

### MVP First

1. Complete Phase 1 setup and verify the project scaffolding exists.
2. Complete Phase 2 foundational backend and frontend configuration.
3. Implement User Story 1 and verify the add/list subscription workflow.
4. Perform Phase 4 polish, confirm the contract, and ensure the MVP remains in-memory only.

### Suggested MVP Scope

- Minimum deliverable: a user can add a feed URL and see it appear in the list.
- Deferred until Extended-MVP: feed fetching, parsing, persistence, deletion of subscriptions, and item display.
