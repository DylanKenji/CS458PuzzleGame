using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public TMP_Text scoreText; // Reference to the Text component displaying the score

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
        CheckVictory(); // Call the method to check for victory condition after updating the score UI
    }

    public void IncrementScore(float points)
    {
        score += (int)points;
        UpdateScoreUI();
        Debug.Log("Score incremented by " + points + ". Total score: " + score);
    }

    // Added method to check for victory condition
    private void CheckVictory()
    {
        if (score >= 500)
        {
            StartCoroutine(LoadHomeRoomAfterDelay());
        }
    }

    IEnumerator LoadHomeRoomAfterDelay()
    {
        // Display "You Win!" for 3 seconds
        scoreText.text = "You Win!";
        yield return new WaitForSeconds(3f);

        // Load the HomeRoom scene after the delay
        RoomManager.MarkRoomCompleted(RoomManager.Room1);
        SceneManager.LoadScene("HomeRoom");
    }
}
