using UnityEngine;

/// <summary>
/// Controller for the Pause Menu UI.
/// Handles button presses for resume, restart, settings, and quit.
/// </summary>
public class PauseMenuController : ScreenController
{
    public void OnResumeButtonPressed()
    {
        Debug.Log("PauseMenu: Resume button pressed.");
        // The primary action is to hide this screen, which is handled by the base class.
        Hide();
    }

    public void OnRestartButtonPressed()
    {
        Debug.Log("PauseMenu: Restart button pressed.");
        // This would typically involve a call to a GameManager to reload the current level.
        // For example: GameManager.Instance.ReloadLevel();
        // Or more simply:
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnSettingsButtonPressed()
    {
        Debug.Log("PauseMenu: Settings button pressed.");
        // This shows the settings screen. Note that this doesn't automatically hide the pause menu,
        // allowing the settings to act as an overlay. A more complex ScreenManager could handle this.
        ScreenManager.Instance.ShowScreen<SettingsScreenController>();
    }

    public void OnQuitButtonPressed()
    {
        Debug.Log("PauseMenu: Quit button pressed.");
        // This would typically return to the main menu.
        // For example: UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreenScene");
        // Or quit the application if in a standalone build.
        // Application.Quit();
    }
}
