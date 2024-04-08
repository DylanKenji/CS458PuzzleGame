using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorManager : MonoBehaviour
{
    // Reference to the cube's renderer
    private Renderer cubeRenderer;

    // Specify the room associated with this cube
    public string roomName;

    void Start()
    {
        // Get the cube's renderer component
        cubeRenderer = GetComponent<Renderer>();

        // Check if the room associated with this cube has been completed
        if (RoomManager.roomCompletionStatus.ContainsKey(roomName) && RoomManager.roomCompletionStatus[roomName])
        {
            // If the room is completed, change the cube's color to green
            cubeRenderer.material.color = Color.green;
        }
        else
        {
            // If the room is not completed, change the cube's color to red
            cubeRenderer.material.color = Color.red;
        }
    }
}
