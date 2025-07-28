using System;
using UnityEngine;

public class DialogueManager
{
    private readonly IDialogueView view;

    public DialogueManager(IDialogueView view)
    {
        this.view = view;
    }

    public void StartDialogue(DialogueGraphSO graph)
    {
        if(graph.entryNode == null)
        {
            return;
        }
        ShowNode(graph.entryNode);
    }

    private void ShowNode(DialogueNodeSO node)
    {
        view.ShowLine(node.text);

        if(node.choices == null || node.choices.Count == 0)
        {
            view.ShowEndPrompt("[Press Space to close]", () => view.EndDialogue());
            return;
        }

        var options = new string[node.choices.Count];
        for(int i = 0; i < node.choices.Count; i++)
        {
            options[i] = node.choices[i].choiceText;
        }

        view.ShowChoices(options, idx =>
        {
            var next = node.choices[idx].nextNode;
            if (next != null)
            {
                ShowNode(next);
            }
            else
            {
                view.ShowEndPrompt("[Press Space to close]", () => view.EndDialogue());
            }
        });
    }
}
