using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorInteractable : XRBaseInteractable
{
    public RoomManager roomManager;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        LoadLevelAndMarkRoomCompleted();
    }

    private void LoadLevelAndMarkRoomCompleted()
    {
        SceneManager.LoadScene("Level1");
        
        if (roomManager != null)
        {
            RoomManager.MarkRoomCompleted(RoomManager.Room1);
        }
        else
        {
            Debug.LogWarning("RoomManager reference is not set on the DoorInteractable.");
        }
    }
}
