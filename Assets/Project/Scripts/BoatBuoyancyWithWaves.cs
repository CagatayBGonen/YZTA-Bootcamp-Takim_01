using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatBuoyancyWithWaves : MonoBehaviour
{
    public float waterLevel = 0f;           // Su yüzeyi yüksekliði
    public float floatStrength = 10f;       // Yüzdürme kuvveti
    public float waveFrequency = 0.5f;      // Dalga sýklýðý
    public float waveAmplitude = 0.5f;      // Dalga yüksekliði

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Dalgalý su yüzeyinin anlýk yüksekliðini hesapla
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
