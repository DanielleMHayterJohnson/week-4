using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public Transform centerPoint; // Drop a GameObject here as the center reference
    public float boundarySize = 10f; // The range from the center where the player can move

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (centerPoint == null)
        {
            Debug.LogWarning("PlayerBounds: CenterPoint is not assigned in the Inspector!");
            return;
        }

        // Define boundaries based on centerPoint
        Vector3 minBounds = centerPoint.position - new Vector3(boundarySize, 0, boundarySize);
        Vector3 maxBounds = centerPoint.position + new Vector3(boundarySize, 10, boundarySize);

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            Mathf.Clamp(transform.position.z, minBounds.z, maxBounds.z)
        );

        // Prevent jittering when using CharacterController
        characterController.enabled = false;
        transform.position = clampedPosition;
        characterController.enabled = true;
    }
}
