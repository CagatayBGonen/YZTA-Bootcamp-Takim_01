using System.Collections.Generic;
using UnityEngine;
// This class contains player traits's levels
[CreateAssetMenu(menuName = "Dialogue/Trait Set")]
public class TraitSet : ScriptableObject
{
    [System.Serializable]
    public class TraitEntry
    {
        public TraitType traitType;
        public int level;
    }

    public List<TraitEntry> traits = new();

    private Dictionary<TraitType, int> traitDict;

    private void OnEnable()
    {
        traitDict = new Dictionary<TraitType, int>();
        foreach(var entry in traits)
        {
            traitDict[entry.traitType] = entry.level;
        }
    }

    public int GetTraitLevel(TraitType type)
    {
        if(traitDict == null)
        {
            OnEnable(); 
        }
        return traitDict.TryGetValue(type, out var value) ? value : 0;
    }

    public void SetTraitLevel(TraitType type, int newLevel)
    {
        foreach(var entry in traits)
        {
            if(entry.traitType == type)
            {
                entry.level = newLevel;
                traitDict[type] = newLevel;
                return;
            }
        }

        // If there is no entry, adding a new one here
        var newEntry = new TraitEntry { traitType = type, level = newLevel};
        traits.Add(newEntry);
        traitDict[type] = newLevel;
    }
}
