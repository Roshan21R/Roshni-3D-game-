using UnityEngine;

/// <summary>
/// Controller for the Title Screen UI.
/// Handles button presses and other UI logic for this specific screen.
/// </summary>
public class TitleScreenController : ScreenController
{
    public void OnPlayButtonPressed()
    {
        Debug.Log("Play button pressed! Transitioning to game...");
        // This would typically load the main game scene or a level select screen.
        // For example: UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    public void OnSettingsButtonPressed()
    {
        Debug.Log("Settings button pressed! Requesting to show Settings screen...");
        // TODO: Create a SettingsScreenController class and uncomment the following line:
        // ScreenManager.Instance.ShowScreen<SettingsScreenController>();
    }

    public void OnProfileButtonPressed()
    {
        Debug.Log("Profile button pressed! Requesting to show Profile screen...");
        // TODO: Create a ProfileSelectController class and uncomment the following line:
        // ScreenManager.Instance.ShowScreen<ProfileSelectController>();
    }
}
