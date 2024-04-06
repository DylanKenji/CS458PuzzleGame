using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public TMP_Text scoreText; // Reference to the Text component displaying the score

    private int score = 0;
    private Color currentColor; // Removed property, directly accessed from ColorChangingCube

    private void Awake()
    {
        Instance = this;
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncrementScore(float points)
    {
        score += (int)points;
        UpdateScoreUI();
        Debug.Log("Score incremented by " + points + ". Total score: " + score);
    }

    // Removed SetCurrentColor method

    // Added method to check if the current color matches the ball color
    public bool IsCurrentColorMatch(Color ballColor)
    {
        return currentColor == ballColor;
    }

    // Added method to update the current color directly from ColorChangingCube
    public void SetCurrentColor(Color newColor)
    {
        currentColor = newColor;
    }
}
