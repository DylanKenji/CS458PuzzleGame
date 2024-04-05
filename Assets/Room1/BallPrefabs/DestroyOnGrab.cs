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
        Color ballColor = GetComponent<Renderer>().material.color; // Get the color of the ball
        if (scoreManager != null && scoreManager.IsCurrentColorMatch(ballColor))
            scoreManager.IncrementScore();

        Destroy(gameObject);
    }
}
