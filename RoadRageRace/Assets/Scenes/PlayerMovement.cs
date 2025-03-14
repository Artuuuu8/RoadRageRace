using UnityEngine;
using Unity.Netcode;

public class PlayerCarController : NetworkBehaviour
{
    public float acceleration = 15f;
    public float maxSpeed = 20f;
    public float steering = 50f;
    public float braking = 10f;
    private Rigidbody rb;

    public override void OnNetworkSpawn()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveInput = 0f;
        float turnInput = 0f;

        moveInput = Input.GetKey(KeyCode.W) ? 1f : (Input.GetKey(KeyCode.S) ? -1f : 0f);
        turnInput = Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f);

        // Apply acceleration only if below max speed
        if (rb.velocity.magnitude < maxSpeed || moveInput < 0)
        {
            AudioManager.Instance.StartCarAccelerationSound();
            rb.AddForce(transform.forward * moveInput * acceleration, ForceMode.Acceleration);
        }

        // Apply turning 
        if (rb.velocity.magnitude > 0.1f)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * turnInput * steering * Time.fixedDeltaTime));
        }

        // Apply braking 
        if (moveInput == 0)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, braking * Time.fixedDeltaTime);
        }
    }

    // Collision detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity *= 0.7f; // Slow down by 30%
            rb.angularVelocity = Vector3.zero; // Stop spin
             AudioManager.Instance.PlayCarCrashSound();
        }

        if (collision.gameObject.CompareTag("Guardrail"))
        {
            rb.velocity *= 0.5f; // Slow down by 50%
            rb.angularVelocity = Vector3.zero; // Stop spin
            AudioManager.Instance.PlayCarCrashSound();
        }
    }

}
