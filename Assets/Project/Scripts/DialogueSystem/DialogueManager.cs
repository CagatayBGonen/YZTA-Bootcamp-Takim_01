using System.Collections.Generic;
using UnityEngine;
/* This class deals with:
 *  - Current Node/dialogue
 *  - Answer options
 *  - Next Node
 *  - Trait Level check
 *  - Dice Success
 *  - UI call
 */
public class DialogueManager : MonoBehaviour
{
    [Header("Connections")]
    public DialogueNodeSO currentNode;
    public TraitSet playerTraits;

    [Header("UI Manager")]
    public DialogueUIManager uiManager;

    public void StartDialogue(DialogueNodeSO startNode) // start the dialogue system with the first node
    {
        currentNode = startNode;
        ShowNode();
    }

    public void ShowNode() // Sends the Node Text and Options to the UI
    {
        if(currentNode == null)
        {
            Debug.Log("CurrentNode is null");
            return;
        }

        // uiManager.DisplayDialogue(currentNode.dialogueText);
        
        List<DialogueOptionSO> options = currentNode.dialogueOptions;

        foreach(DialogueOptionSO option in options)
        {
            // Here we recieve the info of Trait
            TraitType requiredTrait = option.traitCheck.requiredTrait;
            int requiredLevel = option.traitCheck.requiredLevel;
            int playerLevel = playerTraits.GetTraitLevel(requiredTrait);

            // As default it is locked
            DialogueState state = DialogueState.Locked;

            // Here we are dealing with state of the dialogue
            if (requiredTrait == TraitType.None || playerLevel >= requiredLevel)
            {
                state = option.traitCheck.requiresRoll ? DialogueState.Available : DialogueState.Success;
            }
            else if (playerLevel > 0)
            {
                state = DialogueState.Undiscovered;
            }

            option.optionState = state;

            // uiManager.CreateOptionButton(option, () => OnOptionSelected(option));
        }
         
    }
    public void OnOptionSelected(DialogueOptionSO selectedOption) // Checks trait and dice conditions for selected option
    {
        int playerLevel = playerTraits.GetTraitLevel(selectedOption.traitCheck.requiredTrait);
        int required = selectedOption.traitCheck.requiredLevel;

        if (selectedOption.traitCheck.requiresRoll)
        {
            bool success = DiceRollSystem.Evaluate(playerLevel, required, out int finalRoll);
            //uiManager.ShowRollResult(playerLevel, finalRoll, required, success);

            selectedOption.optionState = success ? DialogueState.Success : DialogueState.Failed;

            currentNode = success ? selectedOption.successNode : selectedOption.failureNode;
        }
        else
        {
            currentNode = selectedOption.successNode;
            selectedOption.optionState = DialogueState.Success;
        }

        //uiManager.ClearOptions();
        ShowNode();
    }
}
