# Emoji Battle

Released Android game built in Unity 6 and C#.

Google Play: https://play.google.com/store/apps/details?id=com.sd7gamestudio.emojibattle

## Overview

Emoji Battle is a complete mobile game released on Google Play. The project demonstrates my ability to take a Unity game from prototype to public Android release while handling gameplay logic, UI flow, AI behavior, persistent progress, ads integration, debugging, and build preparation.

The game is a turn-based board battle built around emoji characters, difficulty selection, player progression, rewards, settings, popups, and mobile monetization flow.

## My Role

Solo Unity C# development across gameplay programming, mobile UI implementation, architecture refactoring, persistent data, ads integration, debugging, and Google Play release preparation.

## Key Systems I Built

### Turn-Based Gameplay Flow

Implemented the core gameplay loop around board state, turn state, win checking, game result handling, and UI updates.

Relevant systems include:

- board state;
- cell state;
- turn state;
- move processing;
- win checking;
- game-over result flow;
- result UI and reward result handling.

Engineering value:

- gameplay rules are separated from UI button logic;
- the game loop is easier to debug because board state, turn state, and result calculation are explicit;
- UI reacts to gameplay state instead of owning the rules.

### AI Strategy System

Implemented reusable AI behavior using Strategy Pattern.

Relevant systems include:

- AI strategy interface;
- easy, normal, and hard strategies;
- AI strategy factory;
- AI selection service;
- difficulty display and difficulty UI flow.

Engineering value:

- difficulty behavior is extendable without rewriting the gameplay loop;
- AI logic is isolated from UI and board rendering;
- future strategies can be added as separate classes.

### Progression And Persistent Data

Implemented persistent player progress and game data services.

Relevant systems include:

- save payload model;
- game progress model;
- player profile model;
- storage abstraction;
- game data service;
- save version handling;
- reward rules and emoji progression.

Engineering value:

- storage implementation is hidden behind an interface;
- saved data has a version field for safer future migrations;
- progression is represented as data rather than scattered UI state.

### UI, Lobby, And Popup Flow

Implemented the game UI across lobby, gameplay, settings, results, and informational popups.

Relevant systems include:

- lobby controller, lobby service, and lobby view;
- avatar/emoji selection UI;
- AI difficulty UI;
- popup base classes;
- popup canvas controller;
- popup service;
- result popups;
- settings, no-internet, rewarded, victory, defeat, draw, and complete popups;
- fade/scale UI animation helpers.

Engineering value:

- popup handling is centralized;
- lobby and gameplay screens have dedicated controllers/views;
- UI logic is easier to maintain because it is not mixed directly into core board rules.

### Ads Integration

Implemented Unity Ads integration for rewarded and interstitial ads.

Relevant systems include:

- rewarded ad state tracking;
- initialization/load/show callbacks;
- load timeout handling;
- online/offline checks;
- resume handling after app focus/pause;
- rewarded callback flow;
- interstitial pacing after matches.

Engineering value:

- ad state is visible to UI;
- offline/failed/loading/ready/showing states are explicit;
- ads are integrated into gameplay flow without blocking core game state.

### Services And Mobile Features

Implemented supporting mobile-facing services.

Relevant systems include:

- audio service;
- settings service;
- vibration service;
- internet state service;
- scene fading and UI input helpers.

Engineering value:

- shared app services are separated from scene-specific gameplay code;
- persistent service objects are initialized during bootstrap;
- mobile-specific behavior is handled through dedicated services.

## Architecture

The project is organized into practical layers:

- App/Bootstrap: startup and entry points.
- Domain: AI, board rules, emoji data, progress rules.
- Infrastructure: data models, storage, game data service.
- Presentation: gameplay UI, lobby UI, main view, popups, common UI helpers.
- Services: ads, audio, network state, settings, vibration.

Architecture principles used:

- SRP-style class responsibilities;
- MVC-style separation where it helps readability;
- Strategy Pattern for AI;
- event-driven updates between gameplay and UI;
- service abstractions for app-level systems;
- persistent data separated from presentation state.

## Tech Stack

- Unity 6
- C#
- UGUI
- Unity Ads
- Strategy Pattern
- Event-driven gameplay/UI flow
- Persistent player data
- Android build pipeline
- Google Play release workflow

## What This Project Demonstrates

- Shipping a complete Unity mobile game to Google Play.
- Implementing core gameplay, UI, persistence, ads, and release work in one project.
- Refactoring a prototype toward clearer feature boundaries.
- Handling mobile-specific states such as offline mode, ad loading, app resume, and persistent settings.
- Taking responsibility for the full path from playable prototype to public store release.

## Author

Oleksandr Tokarev  
Unity C# Developer  
Portfolio: https://tokarevdev.github.io/
