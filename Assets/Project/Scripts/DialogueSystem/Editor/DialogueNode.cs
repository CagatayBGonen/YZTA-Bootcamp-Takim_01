using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DialogueNode : Node
{
    public string GUID; // unique ID to Node to distuinguish them.

    public string DialogueText;

    public bool EntryPoint = false;
}
