using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("Ana Menü")]
    public CanvasGroup mainMenuGroup;

    [Header("Win & Lose Panelleri")]
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Karartma")]
    public Image blackOverlay;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        mainMenuGroup.alpha = 1;
        mainMenuGroup.interactable = true;
        mainMenuGroup.blocksRaycasts = true;

        if (blackOverlay != null)
            blackOverlay.color = new Color(0, 0, 0, 0); // Başlangıçta şeffaf
    }

    public void OnStartClicked()
    {
        StartCoroutine(FadeOutMainMenu());
    }

    private IEnumerator FadeOutMainMenu()
    {
        float duration = 1f;
        float time = 0;

        mainMenuGroup.interactable = false;
        mainMenuGroup.blocksRaycasts = false;

        while (time < duration)
        {
            time += Time.deltaTime;
            mainMenuGroup.alpha = Mathf.Lerp(1, 0, time / duration);
            yield return null;
        }

        mainMenuGroup.alpha = 0;
    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        StartCoroutine(FadeInBlackOverlay());
    }

    private IEnumerator FadeInBlackOverlay()
    {
        float duration = 1f;
        float time = 0;

        Color startColor = new Color(0, 0, 0, 0);
        Color endColor = new Color(0, 0, 0, 198f / 255f); // 198/255 ≈ 0.78

        while (time < duration)
        {
            time += Time.deltaTime;
            blackOverlay.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }

        blackOverlay.color = endColor;
    }

    public void OnRestartClicked()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        if (blackOverlay != null)
            blackOverlay.color = new Color(0, 0, 0, 0); // tekrar şeffaf

        mainMenuGroup.alpha = 1;
        mainMenuGroup.interactable = true;
        mainMenuGroup.blocksRaycasts = true;
    }
}
