using System.Collections.Generic;
using UnityEngine;
// This SO contains the dialogues and answers
[CreateAssetMenu(menuName = "Dialogue/Node")]
public class DialogueNodeSO : ScriptableObject
{
    [TextArea(3, 6)]
    public string dialogueText; // the dialogue text

    public List<DialogueOptionSO> dialogueOptions; // list of all the answer options
}
