using UnityEngine;

public class PlayerPushLog : MonoBehaviour
{
    public float pushStrength = 5f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Log")) // Ensure Log has "Log" tag
        {
            Rigidbody logRb = hit.gameObject.GetComponent<Rigidbody>();
            if (logRb != null)
            {
                Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                logRb.AddForce(pushDirection * pushStrength, ForceMode.Impulse);
            }
        }
    }
}

