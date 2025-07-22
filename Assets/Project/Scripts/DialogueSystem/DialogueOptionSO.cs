using UnityEngine;
// This SO represent the answer options in dialogues

[CreateAssetMenu(menuName = "Dialogue/Option")]
public class DialogueOptionSO : ScriptableObject
{
    [TextArea(2,4)] 
    public string optionText; // The text of the answer option

    public DialogueTraitCheck traitCheck;

    public DialogueNodeSO successNode; // The dialogue node to go after a successful dice
    public DialogueNodeSO failureNode; // The dialogue node to go after a failed dice

    [HideInInspector]
    public DialogueState optionState = DialogueState.Undiscovered;
}
