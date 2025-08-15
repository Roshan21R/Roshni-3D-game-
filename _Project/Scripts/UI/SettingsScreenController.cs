using UnityEngine;

/// <summary>
/// Controller for the Settings Screen UI.
/// Handles user interactions with various game settings.
/// </summary>
public class SettingsScreenController : ScreenController
{
    // These methods are intended to be linked to UI controls like Sliders and Toggles in the Unity Editor.

    public void OnMusicVolumeChanged(float value)
    {
        Debug.Log($"Settings: Music Volume changed to {value}");
        // This would typically control an AudioMixer group.
        // For example: AudioManager.Instance.SetMusicVolume(value);
    }

    public void OnSfxVolumeChanged(float value)
    {
        Debug.Log($"Settings: SFX Volume changed to {value}");
        // This would typically control an AudioMixer group.
        // For example: AudioManager.Instance.SetSfxVolume(value);
    }

    public void OnHapticsToggled(bool isOn)
    {
        Debug.Log($"Settings: Haptics toggled to {isOn}");
        // This would control the HapticsManager we built earlier.
        // For example: HapticsManager.Instance.HapticsEnabled = isOn;
    }

    public void OnBackButtonPressed()
    {
        Debug.Log("Settings: Back button pressed. Returning to Title Screen.");
        // This would transition back to the previous screen.
        // For example: ScreenManager.Instance.ShowScreen<TitleScreenController>();
    }
}
