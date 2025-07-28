using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueGraphSO graph;
    public DialogueUI dialogueUI;

    private DialogueManager dialogueManager;

    private void Awake()
    {
        dialogueManager = new DialogueManager(dialogueUI);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player"))
        {
            Debug.Log("Collided with somthing else");
            return;
        }
        Debug.Log("Collided with Player");
        dialogueManager.StartDialogue(graph);
    }
}
