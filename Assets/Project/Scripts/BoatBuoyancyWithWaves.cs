using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatBuoyancyWithWaves : MonoBehaviour
{
    public float waterLevel = 0f;           // Su y�zeyi y�ksekli�i
    public float floatStrength = 10f;       // Y�zd�rme kuvveti
    public float waveFrequency = 0.5f;      // Dalga s�kl���
    public float waveAmplitude = 0.5f;      // Dalga y�ksekli�i

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Dalgal� su y�zeyinin anl�k y�ksekli�ini hesapla
        float wave = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
        float currentWaterLevel = waterLevel + wave;

        if (transform.position.y < currentWaterLevel)
        {
            float depth = currentWaterLevel - transform.position.y;
            Vector3 buoyancyForce = Vector3.up * depth * floatStrength;
            rb.AddForce(buoyancyForce, ForceMode.Acceleration);
        }
    }
}
