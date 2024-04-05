using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    private Color currentColor; // Removed property, directly accessed from ColorChangingCube

    private void Start()
    {
        UpdateScoreUI();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreUI();
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

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
