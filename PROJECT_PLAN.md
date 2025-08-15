# Roshni - Project Development Plan

This document breaks down the high-level Game Design Document (GDD) into a more granular, task-oriented development plan. It is structured into phases, epics, and individual tasks to guide the development process.

---

## Phase 1: Project Foundation & Core UI

This phase focuses on setting up the project, implementing the initial user experience (splash screen), and building the fundamental UI systems that will be shared across the entire game.

### Epic: Initial Project Setup
-   [ ] **Unity Project**: Initialize Unity 2022 LTS project with the Universal Render Pipeline (URP).
-   [ ] **Version Control**: Set up Git and a `.gitignore` file suitable for Unity.
-   [ ] **Folder Structure**: Create a logical folder hierarchy (e.g., `_Project/Scripts`, `_Project/Scenes`, `_Project/Art`, `_Project/Audio`, `_Project/Prefabs`).
-   [ ] **Coding Standards**: Establish a C# coding style guide and linting rules.

### Epic: Splash Screen (`SplashUnboxing`)
-   [ ] **Scene**: Create the `SplashUnboxing` scene.
-   [ ] **Camera Animation**: Implement a C# script for Bezier curve camera movement based on the GDD's keyframes.
-   [ ] **Asset Integration**: Import and configure 3D models (`CrystalPrism`, `PrismBox`) and textures.
-   [ ] **Material Shaders**: Develop or configure the `PBR_Glass_Prismatic` shader.
-   [ ] **Lighting**: Set up scene lighting using the `PrismaticStudio_2k` HDRI and a configurable rim light.
-   [ ] **Timeline Sequence**: Use Unity's Timeline to orchestrate the 4.5-second splash sequence.
    -   [ ] Task: Implement `spawn` and `scale_in` animations.
    -   [ ] Task: Create the `unbox` animation (animating `panel_front`, `panel_top`).
    -   [ ] Task: Develop VFX for `light_spark` and `prism_glitter`.
    -   [ ] Task: Implement the "type on" effect for the "Roshni" text.
    -   [ ] Task: Animate bloom and other post-processing effects (`brand_bloom`).
-   [ ] **Audio Integration**: Implement an audio manager to play SFX and music at specified timestamps.
-   [ ] **Haptics System**: Create a service to trigger haptic feedback on Android.
-   [ ] **2D Fallback**: Design and implement a simple 2D version of the splash for low-spec devices.

### Epic: Brand System & Shared UI Framework
-   [ ] **UI Toolkit**: Set up a global UI stylesheet (USS) in Unity to define brand styles.
-   [ ] **Color Palette**: Implement the brand colors as CSS variables in the global stylesheet.
-   [ ] **Typography**: Import `Outfit`, `Inter`, and `DM Sans` fonts and create TextMeshPro assets and styles.
-   [ ] **UI Components**: Create reusable UI components (prefabs/templates) for buttons, cards, and dialogs that adhere to the `masterUX` patterns.
-   [ ] **Screen Manager**: Develop a system to manage loading, unloading, and transitioning between UI screens.
-   [ ] **Title Screen**: Implement the `TitleScreen` with its specified layout and basic button functionality (Play, Settings, Profile).
-   [ ] **Settings Screen**: Build the `Settings` screen layout with placeholders for all sections.
-   [ ] **Pause Menu**: Create the `PauseMenu` layout.

---

## Phase 2: First Playable - Harvest Realms Core Loop

This phase focuses on building the core gameplay loop for the first game, "Harvest Realms".

### Epic: Harvest Realms - Core Systems
-   [ ] **Data Structures**: Define C# classes for `LevelTemplate`, `World`, `Objectives`, etc.
-   [ ] **Game State Manager**: Implement a system to manage the player's progress, currency, and inventory.
-   [ ] **World Map**:
    -   [ ] Task: Create the `WorldMap` scene.
    -   [ ] Task: Implement basic 3D map navigation (pinch-zoom, pan).
    -   [ ] Task: Procedurally place level nodes on the map.
-   [ ] **Farm Scene**:
    -   [ ] Task: Create the main `Farm` scene.
    -   [ ] Task: Implement a grid system for placing buildings and planting crops.
-   [ ] **Farming Mechanics**:
    -   [ ] Task: Implement the crop lifecycle (planting, growing, ready-for-harvest).
    -   [ ] Task: Implement the harvest action.
    -   [ ] Task: Create the `FarmHUD` UI with resource display and task panel.

### Epic: Economy & Progression
-   [ ] **Currency System**: Implement backend for soft currencies (Coins, XP).
-   [ ] **Level Rewards**: Grant rewards upon successful level completion.
-   [ ] **Persistence**: Implement a save/load system for player data (e.g., using `PlayerPrefs` for now, cloud save later).
-   [ ] **Market**: Implement a basic version of the `MarketScreen` where players can fulfill orders.

---

## Phase 3: Chef Odyssey & Expanding Systems (High-Level)

This outlines the subsequent development focus after the first playable version is established.

### Epic: Chef Odyssey - Core Loop
-   [ ] **System Design**: Adapt/Create systems for cooking gameplay (stations, orders, recipes).
-   [ ] **Kitchen Scene**: Build the core `Kitchen` scene and HUD.
-   [ ] **Recipe System**: Create a flexible system for defining and cooking dishes.

### Epic: Shared Progression & Monetization
-   [ ] **Cross-Game Progress**: Implement systems for shared progression between the two games.
-   [ ] **Shop & IAP**: Build the UI and backend for the `Shop` screen.
-   [ ] **Ads**: Integrate an ad network for opt-in rewarded ads.

### Epic: Polish & Optimization
-   [ ] **Performance**: Profile and optimize memory usage, draw calls, and frame rate.
-   [ ] **Accessibility**: Implement features like color-blind palettes and font scaling.
-   [ ] **Telemetry**: Integrate a telemetry service to track key game events.

---
*This plan is a living document and will be updated as the project progresses.*
