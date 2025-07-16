using UnityEngine;

public enum DialogueState
{
    // Represent the dialogue states for that NPC
    Undiscovered, // not yet seen
    Available,    // Can be said or choose
    Success,      // Successfully discovered 
    Failed,       // Failed the dailogue   
    Locked        // Not having enough trait level
}
