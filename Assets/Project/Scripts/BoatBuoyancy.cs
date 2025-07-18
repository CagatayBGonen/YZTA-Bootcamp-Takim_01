using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatBuoyancy : MonoBehaviour
{
    public float waterLevel = 0f;         // Su yüzeyi yüksekliði (Y ekseni)
    public float floatStrength = 10f;     // Yukarý uygulanan kuvvetin gücü
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.y < waterLevel)
        {
            float depth = waterLevel - transform.position.y;
            Vector3 buoyancyForce = Vector3.up * depth * floatStrength;
            rb.AddForce(buoyancyForce, ForceMode.Acceleration);
        }
    }
}
