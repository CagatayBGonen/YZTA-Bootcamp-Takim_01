using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/TraitSet")]
public class TraitSet : MonoBehaviour
{
    public Dictionary<TraitType, int> traits = new();

    public void SetTrait(TraitType trait, int level) => traits[trait] = level;
    public int GetTraitLevel(TraitType trait) => traits.TryGetValue(trait, out var val) ? val : 0;
}
