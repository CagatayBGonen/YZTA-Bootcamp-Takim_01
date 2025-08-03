using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hell"))
        {
            winCanvas.SetActive(true);
        }
        else if(other.CompareTag("Heaven")||other.CompareTag("Reborn"))
        {
            loseCanvas.SetActive(true);
        }
    }
}
