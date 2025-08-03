using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class DialogueUI : MonoBehaviour, IDialogueView
{
    [Header("UI References")]
    public TMP_Text dialogueText;
    public GameObject dialogueRoot;
    [Tooltip("Assign slot Transforms for up to 3 choices")]
    public Transform[] choiceSlots = new Transform[3];
    public Button choiceButtonPrefab;

    private Action<int> onSelected;
    private Action onContinue;
    private bool awaitingInput;

    void Update()
    {
        if (awaitingInput && Input.GetKeyDown(KeyCode.Space))
        {
            awaitingInput = false;
            onContinue?.Invoke();
        }
    }

    public void ShowLine(string text)
    {
        dialogueRoot.SetActive(true);
        ClearChoices();
        awaitingInput = false;
        dialogueText.text = text;
    }

    public void ShowChoices(string[] options, Action<int> onSelected)
    {
        this.onSelected = onSelected;
        awaitingInput = false;
        ClearChoices();

        int count = Mathf.Min(options.Length, choiceSlots.Length);
        for (int i = 0; i < count; i++)
        {
            if (choiceSlots[i] == null) continue;
            var btn = Instantiate(choiceButtonPrefab, choiceSlots[i]);
            int index = i;
            var tmp = btn.GetComponentInChildren<TMP_Text>();
            if (tmp != null) tmp.text = options[i];
            btn.onClick.AddListener(() => Select(index));
        }
    }

    public void ShowEndPrompt(string prompt, Action onContinue)
    {
        ClearChoices();
        dialogueText.text += "\n\n" + prompt;
        this.onContinue = onContinue;
        awaitingInput = true;
    }

    public void EndDialogue()
    {
        dialogueText.text = string.Empty;
        ClearChoices();
        dialogueRoot.SetActive(false);
    }

    private void ClearChoices()
    {
        foreach (var slot in choiceSlots)
        {
            if (slot == null) continue;
            foreach (Transform child in slot)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void Select(int index)
    {
        ClearChoices();
        onSelected?.Invoke(index);
    }


}
