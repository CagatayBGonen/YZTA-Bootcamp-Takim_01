using UnityEngine;
using UnityEngine.UI;

public class CatchBarAutoFill : MonoBehaviour
{
    public Slider catchBar;
    public float fillSpeed = 0.3f;

    void Update()
    {
        catchBar.value += fillSpeed * Time.deltaTime;
        catchBar.value = Mathf.Clamp(catchBar.value, 0f, 1f);

        if (catchBar.value >= 1f)
        {
            Debug.Log("Nesne yakalandý!");
        }
    }
}
