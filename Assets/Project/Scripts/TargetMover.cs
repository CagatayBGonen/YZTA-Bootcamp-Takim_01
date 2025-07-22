using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeInterval = 1.5f;

    private RectTransform rectTransform;
    private float minY, maxY;
    private float timer;
    private float targetY;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        RectTransform parent = transform.parent.GetComponent<RectTransform>();
        float range = parent.rect.height / 2 - rectTransform.rect.height / 2;
        minY = -range;
        maxY = range;
        SetNewTargetY();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            SetNewTargetY();
            timer = 0f;
        }

        Vector3 pos = rectTransform.localPosition;
        pos.y = Mathf.Lerp(pos.y, targetY, moveSpeed * Time.deltaTime);
        rectTransform.localPosition = pos;
    }

    void SetNewTargetY()
    {
        targetY = Random.Range(minY, maxY);
    }
}
