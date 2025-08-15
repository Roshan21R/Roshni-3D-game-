# Roshni Project - C# Coding Style Guide

This document outlines the coding standards and conventions to be followed for all C# code in the Roshni project. Adhering to these guidelines ensures that our code is clean, readable, and consistent, making it easier to maintain and develop.

---

## 1. Naming Conventions

### 1.1. General Naming
Use PascalCase for all public, protected, and internal members. Use camelCase for private fields and local variables.

-   **Classes, Structs, Enums, Delegates, Interfaces**: `PascalCase`
    -   Example: `public class PlayerController`, `public struct GameData`
-   **Interfaces**: Should be prefixed with `I`.
    -   Example: `public interface IDamageable`
-   **Methods**: `PascalCase`
    -   Example: `public void CalculateScore()`
-   **Properties & Public Fields**: `PascalCase`
    -   Example: `public int Health { get; set; }`, `public float speed;`
-   **Constants (`const`, `static readonly`)**: `ALL_CAPS_SNAKE_CASE`
    -   Example: `private const int MAX_PLAYERS = 4;`

### 1.2. Variable Naming
-   **Private Fields**: `_camelCase` (prefixed with an underscore)
    -   Example: `private float _currentHealth;`
-   **Local Variables**: `camelCase`
    -   Example: `int localScore = 0;`
-   **Method Parameters**: `camelCase`
    -   Example: `public void SetHealth(int newHealth)`

---

## 2. Formatting

### 2.1. Braces
Use the **Allman style**, where each brace (`{` and `}`) is placed on a new line. This improves readability.

```csharp
// Correct
public void MyMethod()
{
    if (someCondition)
    {
        DoSomething();
    }
}

// Incorrect
public void MyMethod() {
    if (someCondition) { DoSomething(); }
}
```

### 2.2. Indentation and Spacing
-   **Indentation**: Use **4 spaces** per indentation level. Do not use tabs.
-   **Spacing**:
    -   Use a single space after a comma between function arguments.
    -   Use single spaces around operators (`=`, `+`, `-`, `*`, `/`, `==`, etc.).
    -   Example: `int x = y + 1;`
    -   Do not use spaces after the opening parenthesis and before the closing parenthesis of method calls.

### 2.3. Line Length
-   Keep lines to a reasonable length to avoid horizontal scrolling.
-   **Soft limit**: 120 characters.

---

## 3. Comments

Good code should be self-documenting, but comments are crucial for explaining the "why," not just the "what."

-   **XML Documentation**: Use XML documentation comments (`///`) for all public and protected members (classes, methods, properties). This is essential for generating documentation and for IntelliSense in the IDE.

    ```csharp
    /// <summary>
    /// Calculates the final score based on player performance.
    /// </summary>
    /// <param name="baseScore">The initial score before bonuses.</param>
    /// <returns>The calculated final score.</returns>
    public int CalculateFinalScore(int baseScore)
    {
        // ...
    }
    ```

-   **In-line Comments**: Use single-line comments (`//`) to clarify complex or non-obvious parts of the code within a method. Avoid redundant comments.

---

## 4. Best Practices

### 4.1. `var` Keyword
-   Use `var` when the type of the variable is obvious from the right-hand side of the assignment.
-   Do not use `var` when the type is not immediately apparent (e.g., a method returning `object` or a non-generic type).

    ```csharp
    // Correct
    var player = new PlayerController();
    var scores = new List<int>();

    // Incorrect (type is not obvious)
    var result = GetSomeData();
    ```

### 4.2. `using` Directives
-   Place all `using` directives at the top of the file, outside of the `namespace` declaration.
-   Keep `using` directives sorted, with `System` namespaces appearing before other namespaces.

### 4.3. Access Modifiers
-   Always explicitly state the access modifier (e.g., `public`, `private`, `protected`). Do not rely on the default (which is `private` for class members).

### 4.4. Unity-Specific
-   Use `[SerializeField]` to expose private fields to the Inspector instead of making them `public`. This maintains encapsulation.
-   Cache component references in `Awake()` or `Start()` instead of calling `GetComponent<T>()` repeatedly in `Update()`.
