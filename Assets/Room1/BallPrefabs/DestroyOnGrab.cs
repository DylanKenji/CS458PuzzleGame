using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyOnGrab : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private ScoreManager scoreManager;

    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.onSelectEntered.AddListener(OnGrab);
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        string ballTag = gameObject.tag; // Get the tag of the ball

        switch (ballTag)
        {
            case "BlueBall":
                scoreManager.IncrementScore(5); // Blue ball grants 5 points
                break;
            case "RedBall":
                scoreManager.IncrementScore(10); // Red ball grants 10 points
                break;
            case "YellowBall":
                scoreManager.IncrementScore(15); // Yellow ball grants 15 points
                break;
            case "GreenBall":
                scoreManager.IncrementScore(20); // Green ball grants 20 points
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }
}
