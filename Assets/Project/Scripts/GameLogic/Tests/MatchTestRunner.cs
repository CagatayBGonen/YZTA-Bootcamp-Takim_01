using UnityEngine;

public class MatchTestRunner : MonoBehaviour
{
    public NPCData testNPC;
    public ItemData selectedItem;
    public IslandData selectedIsland;
    public MatchManager matchManager;

    void Start()
    {
        if (testNPC == null || selectedItem == null || selectedIsland == null || matchManager == null)
        {
            Debug.LogWarning("TestRunner: Eksik veri var.");
            return;
        }

        matchManager.CheckMatch(testNPC, selectedItem, selectedIsland);
    }
}
