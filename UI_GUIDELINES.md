# Roshni Project - Global UI Guidelines

This document outlines high-level rules and principles for the user interface of Roshni to ensure a consistent, accessible, and high-quality user experience.

---

## 1. Core Principles

-   **Project:** Roshni (Harvest Realms & Chef Odyssey)
-   **Platform:** Android (API 26+)
-   **Style:** Master Modern 3D Glassmorphism. UI elements should feel modern, clean, and integrate well with the 3D world, using blur and transparency to create a sense of depth.

## 2. Layout and Sizing

-   **Safe Margins:** All UI elements must respect the device's safe area insets (notches, camera cutouts, etc.). No interactive elements should be placed within the safe area margins.
-   **Touch Targets:** All interactive elements (buttons, toggles, sliders) must have a minimum touch target size of **48dp x 48dp**. This ensures they are easily tappable on a wide range of devices.

## 3. Motion and Animation

-   **Default Transition:** The standard duration for UI animations (e.g., screen fades, panel slides) is **280ms**.
-   **Success Animation:** Animations for successful actions (e.g., completing a task, receiving a reward) should use a "spring" physics-based motion for a more dynamic and satisfying feel.

## 4. Accessibility

Accessibility is a core requirement for the project.

-   **Font Scaling:** The UI must support dynamic font scaling. The available options for the user will be: 85%, 100% (default), 115%, and 130%. All text must remain legible and contained within its UI element at all scales.
-   **Color-Blind Modes:** The game must offer color-blind modes for common types of color vision deficiency. The following modes must be supported, with adjusted color palettes:
    -   Deuteranopia
    -   Protanopia
    -   Tritanopia
