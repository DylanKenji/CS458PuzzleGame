using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    // defining the room name constants
    public const string Room1 = "Room1";
    public const string Room2 = "Room2";
    public const string Room3 = "Room3";

    // all the rooms are set to not completed by default (false)
    public static Dictionary<string, bool> roomCompletionStatus = new Dictionary<string, bool>()
    {
        { Room1, false },
        { Room2, false },
        { Room3, false }
    };

    void Awake()
    {
        // lets the gameobject to exist behond scene changing
        DontDestroyOnLoad(gameObject);
    }

    // when this is called, it marks the room assiciated as completed
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

    // checks to see if rooms are all equal to true (they are all false by default)
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
            // if all rooms are completed, begin the game ending process
            Instance.StartCoroutine(FinishGameCoroutine());
        }
    }

    // after a 5 second delay, it sends the user to the RoomEnd
    private static IEnumerator FinishGameCoroutine()
    {
        Debug.Log("Congratulations! You have completed all rooms. The game is finished.");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("RoomEnd");
    }

    // a static reference to the RoomManager instance. Let's me use access RoomManager across
    // all scenes with needing to have a reference to it
    private static RoomManager instance;
    public static RoomManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RoomManager>();
                if (instance == null)
                {
                    GameObject roomManagerObject = new GameObject("RoomManager");
                    instance = roomManagerObject.AddComponent<RoomManager>();
                }
            }
            return instance;
        }
    }
}
