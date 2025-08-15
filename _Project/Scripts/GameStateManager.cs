using UnityEngine;
using Roshni.Data;

/// <summary>
/// Manages the overall game state, including player data, currency, and progress.
/// Handles saving and loading of the game.
/// </summary>
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    public PlayerData PlayerData { get; private set; }

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

        // Further logic for loading data and modifying it will be added in subsequent steps.
        LoadGame();
    }

    #region Data Modification

    public void AddCoins(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("Cannot add a negative amount of coins. Use RemoveCoins instead.");
            return;
        }
        PlayerData.coins += amount;
        Debug.Log($"{amount} coins added. New total: {PlayerData.coins}");
    }

    public bool RemoveCoins(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("Cannot remove a negative amount of coins.");
            return false;
        }

        if (PlayerData.coins >= amount)
        {
            PlayerData.coins -= amount;
            Debug.Log($"{amount} coins removed. New total: {PlayerData.coins}");
            return true;
        }
        else
        {
            Debug.LogWarning($"Attempted to remove {amount} coins, but player only has {PlayerData.coins}.");
            return false;
        }
    }

    public void AddXp(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("Cannot add a negative amount of XP.");
            return;
        }
        PlayerData.xp += amount;
        Debug.Log($"{amount} XP added. New total: {PlayerData.xp}");
    }

    #endregion

    #region Save & Load

    private const string SaveKey = "Roshni_GameState";

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(PlayerData);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save(); // Force a write to disk, good for critical saves.
        Debug.Log($"Game state saved to PlayerPrefs with key: {SaveKey}");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            PlayerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Game state loaded from PlayerPrefs.");
        }
        else
        {
            // If no save data exists, create a fresh instance.
            PlayerData = new PlayerData();
            Debug.Log("No save data found. Initializing new game state.");
        }
    }

    #endregion
}
