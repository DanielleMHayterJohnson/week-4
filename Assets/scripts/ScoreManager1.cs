using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText; // Drag your UI Text here
    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score; // Update UI
    }
    public void ChangeScore(int scoreChange)
    {
        score +=scoreChange;
        scoreText.text = "Score: " + score; // Update UI
    }
}

