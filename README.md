# Green Fields Card Game

A project to create a flexible and intelligent card game application.

## Project Goal

To build a core card game engine that can be adapted to various card games and user interfaces, allowing players to play against an intelligent AI opponent.

## Current Scope

At this initial stage, the focus is on establishing the foundational concepts of `Card`, `Deck`, and a `Shuffle` function, adhering to clean architecture principles for future extensibility.

## Architecture Overview

This project is structured following a Clean Architecture approach, separating concerns into distinct layers:

* **Core Layer (`src/Core`):** Contains the core business logic and entities (`Card`, `Deck`) that are independent of any specific framework or UI. It defines the `IShuffleDeck` interface.
* **Application Layer (`src/Application`):** Orchestrates the domain entities and use cases. The `CardGameService` currently handles interactions with the `Deck` and `Shuffle` functionality.
* **Infrastructure Layer (`src/Infrastructure`):** Provides concrete implementations for interfaces defined in the domain and application layers, handling external concerns. `RandomShuffleAdapter` is our current shuffle implementation.
* **UI Layer(`src/App`):** Basic UI to interact with the game for now. References Application, GameLogic, and Core. Can be swapped later with Web/WPF etc.

Other supporting projects to add separation and scalability:

* **Games Layer(`src/Games`):** Provides rules and logic specific to games (e.g., how Poker/Blackjack work). Depends on Core

Tests Project:

* **Tests(`tests/Tests.Core`):** Unit tests for Core domain logic (e.g., card models, interfaces).
* **Tests(`tests/Tests.Application`):** Unit tests for Application layer (e.g., services).
* **Tests(`tests/Tests.Infrastructure`):** Unit tests for infrastructure layer (e.g., services).


## Getting Started

```bash
git clone https://github.com/the-string-val/GreenFieldCardGame
cd GreenFieldCardGame
dotnet restore
dotnet build
dotnet run --project src/GreenFieldCardGame.App
```

## 🧪 Run Tests

```bash
dotnet test
```


