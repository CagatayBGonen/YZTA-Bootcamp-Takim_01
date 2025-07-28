using System;
using UnityEngine;

public interface IDialogueView
{
    void ShowLine(string text);
    void ShowChoices(string[] options, Action<int> onSelected);
    void ShowEndPrompt(string prompt, Action onContinue);
    void EndDialogue();
}
