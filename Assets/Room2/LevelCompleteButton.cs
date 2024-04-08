using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class LevelCompleteButton : MonoBehaviour
{
    private XRGrabInteractable interactable;

    [System.Obsolete]
    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.onSelectEntered.AddListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Play destroy sound
        RoomManager.MarkRoomCompleted(RoomManager.Room2);
        SceneManager.LoadScene("HomeRoom");
    }
}
