using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GET_FirstPersonController : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float SprintMultiplier = 2f;
    public float JumpForce = 8f;  // Used for jumping
    public float GroundCheckDistance = 1.5f;
    public float LookSensitivityX = 1f;
    public float LookSensitivityY = 1f;
    public float MinYLookAngle = -90f;
    public float MaxYLookAngle = 90f;
    public Transform PlayerCamera;
    public float Gravity = -15f;

    public Vector3 minBounds = new Vector3(-10f, 0f, -10f); // Minimum X, Y, Z
    public Vector3 maxBounds = new Vector3(10f, 10f, 10f);  // Maximum X, Y, Z

    private Vector3 velocity;
    private float verticalRotation = 0;
    private CharacterController characterController;
    private bool isGrounded;  // Added this

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // **Check if player is on the ground**
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Prevents floating when landing
        }

        // **Movement Input**
        float moveX = Input.GetAxis("Horizontal");  // Left & Right (A/D or Arrow keys)
        float moveZ = Input.GetAxis("Vertical");    // Forward & Backward (W/S or Arrow keys)

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float speed = isSprinting ? WalkSpeed * SprintMultiplier : WalkSpeed;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime); // Moves the player

        // **Jumping**
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(JumpForce * -2f * Gravity);
        }

        // **Apply Gravity**
        velocity.y += Gravity * Time.deltaTime;

        // **Apply vertical movement**
        characterController.Move(velocity * Time.deltaTime);
    }





    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Colony colony = hit.gameObject.GetComponent<Colony>(); // Get the Colony component

        if (hit.gameObject.CompareTag("Sphere") && colony != null) // Ensure it has a Colony script
        {
            if (!colony.selected) // Check if not already selected
            {
                ScoreManager.instance.ChangeScore(colony.point); // Add Score
                colony.selected = true; // Mark as selected
                Destroy(hit.gameObject); // Remove the sphere after collision
            }
        }

        Rigidbody rb = hit.collider.attachedRigidbody;

        // Check if object has a Rigidbody and isn't kinematic
        if (rb != null && !rb.isKinematic)
        {
            Vector3 pushDirection = hit.moveDirection; // Get direction of movement
            pushDirection.y = 0; // Keep force horizontal
            float pushForce = 5f; // Adjust this value to control push strength

            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
// <-- Added missing closing brace



