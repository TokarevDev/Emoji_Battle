# Emoji Battle

Released Android game built with Unity 6 and C#.

Google Play: https://play.google.com/store/apps/details?id=com.sd7gamestudio.emojibattle

Portfolio hub: https://tokarevdev.github.io

Gameplay video: https://youtube.com/shorts/k98hLS689PY?feature=share

## Quick Review

This repository is public as a portfolio/code review sample. Unity vendor packages and imported assets are present, but the portfolio-relevant code lives under `Assets/Scripts/`.

Start here:

- Main project code: `Assets/Scripts/`
- Domain logic: `Assets/Scripts/Domain/`
- Persistence and data services: `Assets/Scripts/Infrastructure/`
- Gameplay, lobby, UI, and popups: `Assets/Scripts/Presentation/`
- Bootstrap and runtime setup: `Assets/Scripts/App/`

## Overview

Emoji Battle is a complete mobile game taken from prototype to public Google Play release during a six-month independent development cycle (Sep 2025 - Feb 2026). It demonstrates end-to-end Unity feature ownership across architecture, turn-based gameplay, AI difficulty, progression, persistent save data, UGUI flow, popup handling, Unity Ads, profiling, Android build preparation, publishing, and post-release support.

The game is a casual board battle built around emoji characters, short match sessions, difficulty selection, unlock progression, settings, offline support, and optional rewarded ads.

## Impact

- Challenge: turn a small Unity prototype into a complete Android game that could pass store review and be maintained after release.
- Action: owned combat flow, AI, persistence, UI states, popups, ads, Android build preparation, publishing steps, and post-release runtime tuning.
- Result: shipped one complete Android game to Google Play within a six-month independent development cycle, with reviewable source code and a complete player loop.

Performance result: improved older-device performance from approximately 30 FPS to a stable 60 FPS. Adaptive 90 FPS and 120 FPS targets were validated on supported high-refresh devices by reducing UI draw calls and separating gameplay from presentation logic.

## My Role

Solo Unity C# development across gameplay programming, mobile UI implementation, architecture refactoring, persistent data, ads integration, debugging, Android build preparation, and Google Play release workflow.

## Key Systems

### Turn-Based Gameplay Flow

- Board state, cell state, turn state, move processing, win checking, game-over handling, result UI, and reward result flow.
- Gameplay rules are separated from UI button logic, making board state, turn state, and result calculation explicit and easier to debug.
- UI reacts to gameplay state instead of owning the core rules.

### AI Strategy System

- Three distinct difficulty modes - easy, normal, and hard - implemented through Strategy Pattern.
- AI strategy selection is isolated from board rendering and lobby UI.
- New difficulty strategies can be added without rewriting the main gameplay loop.

### Progression And Persistent Data

- Player profile, game progress, save payload model, storage abstraction, game data service, save version field, reward rules, and emoji progression.
- Persistent player state is represented as data instead of being scattered through UI components.
- Storage implementation is hidden behind an interface for safer future changes.

### UI, Lobby, And Popup Flow

- Lobby controller/service/view, avatar selection, difficulty UI, result screens, settings, no-internet flow, rewarded ad prompts, victory/defeat/draw/complete popups, and animation helpers.
- Popup handling is centralized through a popup service and canvas controller.
- Screen-specific UI logic is kept separate from board rules and persistence.

### Ads And Mobile Runtime States

- Unity Ads rewarded/interstitial flow, ad state tracking, load timeout handling, online/offline checks, app focus/resume handling, and interstitial pacing after matches.
- Ad state is explicit for UI, so failed/loading/ready/showing states do not block core gameplay state.
- Mobile-facing services include audio, settings, vibration, internet state, scene fading, and UI input helpers.

## Architecture

The project is organized into practical layers:

- App/Bootstrap: startup and entry points.
- Domain: AI, board rules, emoji data, progress rules.
- Infrastructure: data models, storage, game data service.
- Presentation: gameplay UI, lobby UI, main view, popups, common UI helpers.
- Services: ads, audio, network state, settings, vibration.

Architecture principles used:

- SRP-style class responsibilities.
- MVC-style separation where it improves readability.
- Strategy Pattern for AI behavior.
- Event-driven gameplay/UI updates where they reduce coupling.
- Service abstractions for app-level systems.
- Persistent data separated from presentation state.

## Code Review Map

- Main project code: `Assets/Scripts/`
- Domain logic: `Assets/Scripts/Domain/`
- Persistence and data services: `Assets/Scripts/Infrastructure/`
- Gameplay, lobby, UI, and popups: `Assets/Scripts/Presentation/`
- Bootstrap and runtime setup: `Assets/Scripts/App/`

Unity vendor packages and imported assets are present in the repository, but the portfolio-relevant code lives under `Assets/Scripts/`.

## Tech Stack

Unity 6, C#, UGUI, Strategy Pattern, event-driven gameplay/UI flow, Unity Ads, persistent save data, Android build pipeline, Google Play release workflow, Unity Profiler, UI draw-call optimization, adaptive 60/90/120 FPS targets.

## Repository Hygiene

Release signing credentials, store secrets, and private deployment files are intentionally not kept in the repository. The public repo is meant for source review and project structure inspection.

## Author

Oleksandr Tokarev

Unity Developer | C# Gameplay Programmer

Email: otokarevdev@gmail.com

Portfolio: https://tokarevdev.github.io/
