using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/Node")]
public class DialogueNodeSO : ScriptableObject
{
    [TextArea(2, 6)] public string dialogueText;
    public TraitCondition traitCheck;

    public List<ResponseOptionSO> responseOptions;
    public DialogueNodeSO successNode;
    public DialogueNodeSO failueNode;
}
