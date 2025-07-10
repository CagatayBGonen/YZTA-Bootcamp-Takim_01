using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/ResponseOption")]
public class ResponseOptionSO : ScriptableObject
{
    public string responseText;
    public DialogueNodeSO nextNode;
    public TraitType requiredTrait;
    public int requiredLevel;
}
