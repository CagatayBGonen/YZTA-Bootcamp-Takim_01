using UnityEngine;
using UnityEngine.UI;

public class FishingGameManager : MonoBehaviour
{
    public RectTransform catcher;
    public RectTransform target;
    public Image progressFill;

    public float fillSpeed = 0.2f;
    private float progress = 0f;

    void Update()
    {
        if (IsOverlapping())
        {
            progress += fillSpeed * Time.deltaTime;
        }
        else
        {
            progress -= fillSpeed * Time.deltaTime;
        }

        progress = Mathf.Clamp01(progress);
        Vector2 size = progressFill.rectTransform.sizeDelta;
        size.y = progress * 350f; // Bar yüksekliðiyle ayný olmalý
        progressFill.rectTransform.sizeDelta = size;
    }

    bool IsOverlapping()
    {
        float catcherTop = catcher.localPosition.y + catcher.rect.height / 2;
        float catcherBottom = catcher.localPosition.y - catcher.rect.height / 2;
        float targetTop = target.localPosition.y + target.rect.height / 2;
        float targetBottom = target.localPosition.y - target.rect.height / 2;

        return !(catcherTop < targetBottom || catcherBottom > targetTop);
    }
}

