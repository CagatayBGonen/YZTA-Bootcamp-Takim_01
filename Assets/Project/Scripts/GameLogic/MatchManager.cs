using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public void CheckMatch(NPCData npc, ItemData item, IslandData island)
    {
        bool isItemCorrect = item.itemID == npc.correctItemID;
        bool isIslandCorrect = island.islandID == npc.correctIslandID;

        if(isItemCorrect && isIslandCorrect)
        {
            OnPerfectMatch(npc);
        }
        else if(isItemCorrect || isIslandCorrect)
        {
            OnPartialMatch(npc);
        }
        else
        {
            OnMismatch(npc);
        }
    }
    void OnPerfectMatch(NPCData npc)
    {
        Debug.Log($"{npc.npcName} found peace. Perfect match.");
        // TODO: VFX, sound, fade-out, score++
    }
    void OnPartialMatch(NPCData npc)
    {
        Debug.Log($"{npc.npcName} moved on, but not fully at peace.");
        // TODO: sadder music, slower fade
    }

    void OnMismatch(NPCData npc)
    {
        Debug.Log($"{npc.npcName} is still restless. Try again.");
        // TODO: red glow, error sound, NPC stays / respawns later
    }
}
