using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "GameData/NPC")]
public class NPCData : ScriptableObject
{
    public int npcID;
    public string npcName;
    [TextArea(3, 6)] public string backstory;
    public int correctItemID;
    public int correctIslandID;
}
