using UnityEngine;

[System.Serializable]
public class DialogueTraitCheck // Contains the Lock-Key and dice logic. Puts trait limits to options.
{
    public TraitType requiredTrait = TraitType.None; // required trait to open this dialogue
    public int requiredLevel = 0; // What level that trait needs to be successful
    public bool requiresRoll = false; // If the dialogues needs to have a dice roll to determine its success

    public bool Evaluate(int playerTraitLevel) // Returns a boolean value whether dialogue is success or not
    {
        int roll = Random.Range(1, 21); // rolls random number between determined numbers
        return (roll + playerTraitLevel) >= requiredLevel;
    }
}
