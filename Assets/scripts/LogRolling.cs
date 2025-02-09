using UnityEngine;

public class LogRolling : MonoBehaviour
{
    public float rollSpeed = 10f; // Speed of the log rolling
    private Rigidbody rb;
    private bool isPlayerTouching = false; // Tracks if player is touching the log

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        if (isPlayerTouching) // Allow rolling only when player is touching
        {
            float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
            float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow

            // Apply torque to roll the log
            Vector3 rollDirection = new Vector3(vertical, 0, -horizontal);
            rb.AddTorque(rollDirection * rollSpeed, ForceMode.Force);
        }
    }

    // Detect when player touches the log
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the collider is the player
        {
            isPlayerTouching = true;
        }
    }

    // Detect when player stops touching the log
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = false;
        }
    }
}


