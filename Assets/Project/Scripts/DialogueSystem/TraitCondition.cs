using UnityEngine;

[System.Serializable]
public class TraitCondition : MonoBehaviour
{
    public TraitType TraitType;
    public int threshold;
    public bool requiresRoll;

    public bool Evaluate(int traitValue)
    {
        int roll = Random.Range(0, 21); // d20'e gore
        return (roll + traitValue) >= threshold;
    }
}
