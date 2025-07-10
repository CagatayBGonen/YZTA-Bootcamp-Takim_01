using UnityEngine;

public class DiceRollSystem : MonoBehaviour
{
    public static bool RollWithModifier(int threshold, int traitValue)
    {
        int roll = Random.Range(0, 21); // d20'e gore
        return roll + traitValue >= threshold;
    }
}
