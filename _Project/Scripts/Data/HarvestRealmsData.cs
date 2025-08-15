using System.Collections.Generic;

namespace Roshni.HarvestRealms.Data
{
    /// <summary>
    /// Enum representing the different worlds in Harvest Realms.
    /// </summary>
    public enum WorldName
    {
        Meadow, Coastal, Desert, Alpine, Tropical, Tundra, Volcanic, Cloud, Neon, Crystal
    }

    /// <summary>
    /// Enum for the different types of level objectives.
    /// </summary>
    public enum ObjectiveType
    {
        Deliver, Harvest
    }

    [System.Serializable]
    public class LevelObjective
    {
        public ObjectiveType type;
        public string item; // Could be crop, product, etc.
        public int quantity;
    }

    [System.Serializable]
    public class LevelConstraints
    {
        public int timeSeconds;
        public int availableSlots;
        public int energyCapacity;
    }

    [System.Serializable]
    public class LevelRewards
    {
        public int coins;
        public int xp;
        public int rolls;
    }

    /// <summary>
    /// A ScriptableObject or serializable class to define a level's properties.
    /// Based on the GDD levelTemplate.
    /// </summary>
    [System.Serializable]
    public class HarvestRealmsLevelTemplate
    {
        public int levelId;
        public WorldName world;
        public List<LevelObjective> objectives;
        public LevelConstraints constraints;
        public List<string> modifiers; // e.g., "ColdSnap", "PriceSurge:Wool"
        public LevelRewards rewards;
        public List<int> starGoals;
    }
}
