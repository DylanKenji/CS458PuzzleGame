using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // Define constants for room names
    public const string Room1 = "Room1";
    public const string Room2 = "Room2";
    public const string Room3 = "Room3";

    // Dictionary to store room completion status
    public static Dictionary<string, bool> roomCompletionStatus = new Dictionary<string, bool>()
    {
        { Room1, false },
        { Room2, false },
        { Room3, false }
    };

    void Awake()
    {
        // Ensure this GameObject persists across scene changes
        DontDestroyOnLoad(gameObject);
    }

    // Call this method to mark a room as completed
    public static void MarkRoomCompleted(string roomName)
    {
        if (roomCompletionStatus.ContainsKey(roomName))
        {
            roomCompletionStatus[roomName] = true;
            CheckAllRoomsCompleted();
        }
        else
        {
            Debug.LogWarning("Room name not recognized: " + roomName);
        }
    }

    // Call this method to check if all rooms are completed
    private static void CheckAllRoomsCompleted()
    {
        bool allRoomsCompleted = true;

        foreach (bool completed in roomCompletionStatus.Values)
        {
            if (!completed)
            {
                allRoomsCompleted = false;
                break;
            }
        }

        if (allRoomsCompleted)
        {
            FinishGame();
        }
    }

    // Call this method to finish the game
    public static void FinishGame()
    {
        Debug.Log("Congratulations! You have completed all rooms. The game is finished.");
    }
}
