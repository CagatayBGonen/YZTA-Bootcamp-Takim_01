using UnityEngine;

[System.Serializable]
public class TraitCondition
{
    public TraitType TraitType;
    public int threshold;
    public bool requiresRoll;

    public bool Evaluate(int traitValue)
    {
        int roll = Random.Range(0, 21); // d20'e gore
        Debug.Log("Evaluate Roll: " + roll + " Required Roll: " + threshold);
        return (roll + traitValue) >= threshold;
    }
}
