using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    public float acceleration = 15f;
    public float maxSpeed = 20f;
    public float steering = 50f;
    public float braking = 10f;
    private Rigidbody rb;

    public bool isPlayer1 = true; // Toggle for player controls
    private bool raceStarted = false; // Prevents movement before race starts

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!raceStarted) return; // Prevent movement before race starts
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveInput = 0f;
        float turnInput = 0f;

        // Player 1 (WASD)
        if (isPlayer1)
        {
            moveInput = Input.GetKey(KeyCode.W) ? 1f : (Input.GetKey(KeyCode.S) ? -1f : 0f);
            turnInput = Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f);
        }
        // Player 2 (Arrow Keys)
        else
        {
            moveInput = Input.GetKey(KeyCode.UpArrow) ? 1f : (Input.GetKey(KeyCode.DownArrow) ? -1f : 0f);
            turnInput = Input.GetKey(KeyCode.LeftArrow) ? -1f : (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f);
        }

        // Apply acceleration only if below max speed
        if (rb.velocity.magnitude < maxSpeed || moveInput < 0)
        {
            AudioManager.Instance.StartCarAccelerationSound(); // Start engine sound
            rb.AddForce(transform.forward * moveInput * acceleration, ForceMode.Acceleration);
        }

        // Apply turning (only when moving)
        if (rb.velocity.magnitude > 0.1f)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * turnInput * steering * Time.fixedDeltaTime));
        }

        // Apply braking (smooth stopping)
        if (moveInput == 0)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, braking * Time.fixedDeltaTime);
        }
    }

    // Collision detection
    private void OnCollisionEnter(Collision collision)
    {
        // If the car hits another player, slow it down
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayCarCrashSound(); // Play crash sound
            rb.velocity *= 0.7f; // Reduce speed by 30%
            rb.angularVelocity = Vector3.zero; // Stop unnecessary spinning
        }

        // If the car hits the guardrail, slow it down
        if (collision.gameObject.CompareTag("Guardrail"))
        {
            AudioManager.Instance.PlayCarCrashSound(); // Play crash sound
            rb.velocity *= 0.5f; // Reduce speed by 50%
            rb.angularVelocity = Vector3.zero; // Stop unwanted spin
        }
    }

    // Call this from GameController to start the race
    public void StartRace()
    {
        raceStarted = true;
    }
}