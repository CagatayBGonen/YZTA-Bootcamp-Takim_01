using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class DialogueUI : MonoBehaviour, IDialogueView
{
    public Text dialogueText;
    public Transform choicesParent;
    public Button choiceButtonPrefab;

    private Action<int> onSelected;

    public void ShowLine(string text)
    {
        ClearChoices();
        dialogueText.text = text;
    }

    public void ShowChoices(string[] options, Action<int> onSelected)
    {
        this.onSelected = onSelected;
        ClearChoices();
        for (int i = 0; i < options.Length; i++)
        {
            var btn = Instantiate(choiceButtonPrefab,choicesParent);
            int index = i;
            btn.GetComponentInChildren<Text>().text = options[i];
            btn.onClick.AddListener(() => Select(index));
        }
    }

    public void EndDialogue()
    {
        dialogueText.text = string.Empty;
        ClearChoices();
    }

    private void ClearChoices()
    {
        foreach(Transform child in choicesParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void Select(int index)
    {
        ClearChoices();
        onSelected?.Invoke(index);
    }


}
