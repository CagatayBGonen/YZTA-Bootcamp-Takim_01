using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    public float moveSpeed = 10f;         // İleri-geri hareket hızı
    public float turnSpeed = 50f;         // Dönme hızı
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");   // W/S → ileri/geri
        float turnInput = Input.GetAxis("Horizontal"); // A/D → sola/sağa

        // İleri/geri kuvvet uygula
        Vector3 force = transform.forward * moveInput * moveSpeed;
        rb.AddForce(force, ForceMode.Force);

        // Dönme hareketi uygula
        Quaternion rotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * rotation);
    }
}

