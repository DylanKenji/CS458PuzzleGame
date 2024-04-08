using UnityEngine;
using TMPro;

public class ShowMessageAfterCondition : MonoBehaviour
{
    public TMP_Text messageText;
    public bool allRoomsCompleted = false;

    void Start()
    {
        // Initially, hide the message
        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (allRoomsCompleted)
        {
            // Show the message
            if (messageText != null)
                messageText.gameObject.SetActive(true);

            // Call any additional finishing functions if needed
            FinishGame();
        }
    }

    void FinishGame()
    {
        // Add any logic to finish the game
        Debug.Log("Game finished!");
    }
}
