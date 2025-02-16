using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public int scoreValue = 10; // Set to -10 for objects that decrease score

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager

        if (scoreManager != null)
        {
            scoreManager.ChangeScore(scoreValue); // Add or subtract points
            Destroy(gameObject); // Remove the object after collision
        }
    }
}

