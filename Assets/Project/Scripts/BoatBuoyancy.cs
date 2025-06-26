using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatBuoyancy : MonoBehaviour
{
    public float waterLevel = 0f;         // Su y�zeyi y�ksekli�i (Y ekseni)
    public float floatStrength = 10f;     // Yukar� uygulanan kuvvetin g�c�
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
