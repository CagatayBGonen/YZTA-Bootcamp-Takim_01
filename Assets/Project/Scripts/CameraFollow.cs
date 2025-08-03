using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("Takip edilecek transform.")]
    [SerializeField] private Transform playerTransform;

    [Tooltip("Dünya uzayýnda sabit ofset (X,Y,Z).")]
    [SerializeField] private Vector3 cameraOffset = new Vector3(-26f, 9f, -1.5f);

    [Tooltip("Takip ederken pozisyonu yumuþatmak için hýz.")]
    [SerializeField, Range(0f, 1f)] private float smoothSpeed = 0.1f;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = playerTransform.position + cameraOffset;

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
}
