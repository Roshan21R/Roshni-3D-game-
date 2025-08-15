using UnityEngine;

/// <summary>
/// Manages all haptic feedback in the game.
/// Implemented as a persistent Singleton.
/// </summary>
public class HapticsManager : MonoBehaviour
{
    public static HapticsManager Instance { get; private set; }

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
        }
    }

    // Further logic for triggering haptics will be added in subsequent steps.

    public bool HapticsEnabled { get; set; } = true; // This can be controlled by a settings menu.

    /// <summary>
    /// Triggers a haptic feedback pattern.
    /// </summary>
    /// <param name="pattern">The name of the haptic pattern to play (e.g., "tick", "rumble_soft").</param>
    public void TriggerHaptic(string pattern)
    {
        if (!HapticsEnabled)
        {
            return;
        }

        // Ensure this code only runs on actual mobile devices and not in the editor.
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        switch (pattern)
        {
            case "tick":
            case "click":
                // TODO: This is a placeholder. A real implementation would use a haptics asset
                // to differentiate between a 'tick' and a 'click'.
                Handheld.Vibrate();
                break;

            case "rumble_soft":
            case "pulse_long":
                // TODO: This is a placeholder. A real implementation would use a haptics asset
                // for longer, more complex rumble patterns.
                Handheld.Vibrate();
                break;

            default:
                Debug.LogWarning($"HapticsManager: Unknown haptic pattern '{pattern}' requested.");
                break;
        }
#endif
    }
}
