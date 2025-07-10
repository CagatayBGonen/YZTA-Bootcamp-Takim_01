using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueNodeSO currentNode;
    public TraitSet playerTraits;

    public void StartDialogue(DialogueNodeSO startNode)
    {
        currentNode = startNode;
        ShowNode();
    }
    public void ShowNode()
    {
        Debug.Log("NPC says: " + currentNode.dialogueText);

        if (currentNode.traitCheck.requiresRoll)
        {
            int playerValue = playerTraits.GetTraitLevel(currentNode.traitCheck.TraitType);
            bool result = currentNode.traitCheck.Evaluate(playerValue);
            currentNode = result ? currentNode.successNode : currentNode.failueNode;
        } else
        {
            foreach(var option in currentNode.responseOptions)
            {
                Debug.LogWarning("Option: " +  option.responseText);
            }
        }
    }
}
