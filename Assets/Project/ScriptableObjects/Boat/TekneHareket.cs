using UnityEngine;

public class TekneHareket : MonoBehaviour
{

    public float hiz = 5f;
    public float donmeHizi = 100f;
    public Transform yelkenTransform;
    public float yelkenAciMaksimum = 25f;
    public float yelkenDonusHizi = 5f;
    public Animator rowingMovement;
    private float inputYatay;
    private float inputDikey;
    private Quaternion yelkenBaslangicRotasyonu;


    void Start()
    {
        if (yelkenTransform != null)
        {
            yelkenBaslangicRotasyonu = yelkenTransform.localRotation;
        }
    }

    void Update()
    {
        inputYatay = Input.GetAxis("Horizontal");
        inputDikey = Input.GetAxis("Vertical");

        // Tekne hareketi
        transform.Rotate(Vector3.up, inputYatay * donmeHizi * Time.deltaTime);
        transform.Translate(Vector3.forward * inputDikey * hiz * Time.deltaTime);

        // Yelken kontrolü
        if (yelkenTransform != null)
        {
            Quaternion hedefRotasyon;
            if (inputYatay > 0.01f)
                hedefRotasyon = Quaternion.Euler(-yelkenAciMaksimum, 0f, 0f);
            else if (inputYatay < -0.01f)
                hedefRotasyon = Quaternion.Euler(yelkenAciMaksimum, 0f, 0f);
            else
                hedefRotasyon = Quaternion.identity;

            Quaternion hedefLocalRotasyon = yelkenBaslangicRotasyonu * hedefRotasyon;
            yelkenTransform.localRotation = Quaternion.Slerp(
                yelkenTransform.localRotation,
                hedefLocalRotasyon,
                Time.deltaTime * yelkenDonusHizi
            );
        }

        bool hareketEdiyor = Mathf.Abs(inputDikey) > 0.01f;
        if (rowingMovement != null)
        {
            rowingMovement.SetBool("isMoving", hareketEdiyor);
        }
        if (rowingMovement != null)
        {
            rowingMovement.SetBool("isMoving", hareketEdiyor);
        }
    }
}