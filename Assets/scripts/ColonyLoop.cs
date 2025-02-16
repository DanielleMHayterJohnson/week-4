using UnityEngine;

public class ColonyLoop : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Sphere"))
        {
            if (hit.gameObject.GetComponent<Colony>().selected == false)//checks to see if selected
            {
                ScoreManager.instance.ChangeScore(hit.gameObject.GetComponent<Colony>().point); // Increase Score
                hit.gameObject.GetComponent<Colony>().selected = true; //Marks that colony has been selected
            }
            Destroy(hit.gameObject); // Remove the sphere after collision

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
