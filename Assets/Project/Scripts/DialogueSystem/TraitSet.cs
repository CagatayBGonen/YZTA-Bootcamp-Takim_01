using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/TraitSet")]
public class TraitSet : ScriptableObject
{
    [System.Serializable]
    public class TraitEntry
    {
        public TraitType traitType;
        public int level;
    }

    public List<TraitEntry> traitList = new();

    // Runtime için dictionary'ye çevirmek
    private Dictionary<TraitType, int> traitDict;

    private void OnEnable()
    {
        traitDict = new Dictionary<TraitType, int>();
        foreach (var entry in traitList)
        {
            traitDict[entry.traitType] = entry.level;
        }
    }

    public int GetTraitLevel(TraitType trait)
    {
        if (traitDict == null) OnEnable(); // safety net
        return traitDict.TryGetValue(trait, out var val) ? val : 0;
    }

    public void SetTraitLevel(TraitType trait, int level)
    {
        foreach (var entry in traitList)
        {
            if (entry.traitType == trait)
            {
                entry.level = level;
                traitDict[trait] = level;
                return;
            }
        }

        // Eðer yoksa yeni ekle
        var newEntry = new TraitEntry { traitType = trait, level = level };
        traitList.Add(newEntry);
        traitDict[trait] = level;
    }
}
