using UnityEngine;

[CreateAssetMenu(fileName = "New Island", menuName = "GameData/Island")]
public class IslandData : ScriptableObject
{
    public int islandID;
    public string islandName;
    public Sprite previewImage;
}
