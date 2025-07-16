using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogueUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text dialogueText;
    public Transform optionButtonContainer;
    public GameObject optionButtonPrefab;
    public TMP_Text rollResultText;

    private List<GameObject> activeButtons = new();

    public void DisplayDialogue(string text)
    {
        dialogueText.text = text;
    }

    public void CreateOptionButton(DialogueOptionSO option, System.Action<DialogueOptionSO> onClick)
    {
        GameObject newButton = Instantiate(optionButtonPrefab, optionButtonContainer);
        Button btn = newButton.GetComponent<Button>();
        TMP_Text btnText = newButton.GetComponentInChildren<TMP_Text>();

        btnText.text = option.optionText;

        // Renk ve durum ayarý
        switch (option.optionState)
        {
            case DialogueState.Locked:
                btn.interactable = false;
                btnText.color = Color.red;
                break;
            case DialogueState.Available:
                btn.interactable = true;
                btnText.color = Color.yellow;
                break;
            case DialogueState.Success:
                btn.interactable = true;
                btnText.color = Color.green;
                break;
            case DialogueState.Failed:
                btn.interactable = false;
                btnText.color = Color.gray;
                break;
            case DialogueState.Undiscovered:
                btn.interactable = false;
                btnText.color = Color.white;
                break;
        }

        DialogueOptionSO optionCopy = option; // closure fix
        btn.onClick.AddListener(() => onClick(optionCopy));

        activeButtons.Add(newButton);
    }

    public void ClearOptions()
    {
        foreach (GameObject button in activeButtons)
        {
            Destroy(button);
        }
        activeButtons.Clear();
        rollResultText.text = "";
    }

    public void ShowRollResult(int traitLevel, int totalRoll, int threshold, bool success)
    {
        Debug.Log("Roll sonucu fonksiyonu çaðrýldý.");
        rollResultText.text = $"Rolled {totalRoll - traitLevel} + Trait({traitLevel}) = {totalRoll} / Needed: {threshold}\n" +
                              (success ? "<color=green>Success!</color>" : "<color=red>Failed!</color>");
    }
}
