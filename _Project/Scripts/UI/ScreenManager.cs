using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Manages the instantiation, registration, and transitions of all UI screens.
/// Implemented as a persistent Singleton.
/// </summary>
public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance { get; private set; }

    private List<ScreenController> _screenControllers = new List<ScreenController>();

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Logic for screen registration and showing/hiding will be added in subsequent steps.

    public void RegisterScreen(ScreenController screen)
    {
        if (!_screenControllers.Contains(screen))
        {
            _screenControllers.Add(screen);
        }
    }

    /// <summary>
    /// Shows a specific screen and hides all others.
    /// </summary>
    /// <typeparam name="T">The type of the ScreenController to show.</typeparam>
    public void ShowScreen<T>() where T : ScreenController
    {
        T targetScreen = _screenControllers.FirstOrDefault(s => s is T) as T;

        if (targetScreen == null)
        {
            Debug.LogWarning($"ScreenManager: Screen of type {typeof(T).Name} not found.");
            return;
        }

        // Hide all other screens and show the target one.
        foreach (var screen in _screenControllers)
        {
            if (screen == targetScreen)
            {
                screen.Show();
            }
            else
            {
                screen.Hide();
            }
        }
    }
}
