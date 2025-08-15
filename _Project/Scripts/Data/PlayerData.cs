namespace Roshni.Data
{
    /// <summary>
    /// A plain C# class that holds all player data that needs to be saved.
    /// Marked as Serializable so it can be converted to JSON by JsonUtility.
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        public int coins;
        public int xp;
        // More fields like inventory, player level, etc., can be added here later.

        public PlayerData()
        {
            // Default values for a new player
            coins = 0;
            xp = 0;
        }
    }
}
