using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LoadSceneOnGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Ensure XRGrabInteractable component exists on this object
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable component not found on " + gameObject.name);
        }
        else
        {
            // Subscribe to the OnSelectEntered event
            grabInteractable.onSelectEntered.AddListener(OnGrab);
        }
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Load your new scene when the object is grabbed
        SceneManager.LoadScene("HomeRoom");

        // Mark Room1 as completed
        RoomManager.MarkRoomCompleted(RoomManager.Room.Room1);
    }
}
