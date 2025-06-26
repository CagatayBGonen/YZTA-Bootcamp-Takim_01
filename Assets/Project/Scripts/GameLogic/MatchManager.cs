using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public void CheckMatch(NPCData npc, ItemData item, IslandData island)
    {
        bool isItemCorrect = item.itemID == npc.correctItemID;
        bool isIslandCorrect = island.islandID == npc.correctIslandID;

        if(isItemCorrect && isIslandCorrect)
        {
            OnPerfectMatch(npc,item,island);
        }
        else if(isItemCorrect || isIslandCorrect)
        {
            OnPartialMatch(npc, item, island);
        }
        else
        {
            OnMismatch(npc, item, island);
        }
    }
    void OnPerfectMatch(NPCData npc, ItemData item, IslandData island)
    {
        Debug.Log($"{npc.npcName} found peace. Perfect match.");
        Debug.Log($"NPC itemi = {npc.correctItemID}, olan item = {item.itemID} ");
        Debug.Log($"NPC isldan = {npc.correctIslandID}, olan island = {island.islandID} ");
        // TODO: VFX, sound, fade-out, score++
    }
    void OnPartialMatch(NPCData npc, ItemData item, IslandData island)
    {
        Debug.Log($"{npc.npcName} moved on, but not fully at peace.");
        Debug.Log($"NPC itemi = {npc.correctItemID}, olan item = {item.itemID} ");
        Debug.Log($"NPC isldan = {npc.correctIslandID}, olan island = {island.islandID} ");
        // TODO: sadder music, slower fade
    }

    void OnMismatch(NPCData npc, ItemData item, IslandData island)
    {
        Debug.Log($"{npc.npcName} is still restless. Try again.");
        Debug.Log($"NPC itemi = {npc.correctItemID}, olan item = {item.itemID} ");
        Debug.Log($"NPC isldan = {npc.correctIslandID}, olan island = {island.islandID} ");
        // TODO: red glow, error sound, NPC stays / respawns later
    }
}
