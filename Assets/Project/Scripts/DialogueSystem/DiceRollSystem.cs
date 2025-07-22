using UnityEngine;
// This class control the dice and success
public class DiceRollSystem : MonoBehaviour
{
    public static int RollDice()
    {
        return Random.Range(1, 21); // dice range
    }

    public static bool Evaluate(int traitLevel, int requiredThreshold, out int finalRoll)
    {
        int roll = RollDice();
        finalRoll = roll + traitLevel;
        return finalRoll >= requiredThreshold;
    }
}
