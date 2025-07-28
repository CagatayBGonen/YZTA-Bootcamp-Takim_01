using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNode", menuName = "Dialogue/Node")]
public class DialogueNodeSO : ScriptableObject
{
    [TextArea]
    public string text;
    public List<DialogueChoice> choices = new List<DialogueChoice>();
}
