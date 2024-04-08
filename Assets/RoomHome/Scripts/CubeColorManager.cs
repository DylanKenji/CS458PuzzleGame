using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorManager : MonoBehaviour
{
    private Renderer cubeRenderer;

    // specifices the room associated with the cube
    public string roomName;

    void Start()
    {
        // Get the cube's renderer component
        cubeRenderer = GetComponent<Renderer>();

        // checks if the room associated with the cube is marked as completed, IF so, the color changes to green, ELSE, it remains red
        if (RoomManager.roomCompletionStatus.ContainsKey(roomName) && RoomManager.roomCompletionStatus[roomName])
        {
            cubeRenderer.material.color = Color.green;
        }
        else
        {
            cubeRenderer.material.color = Color.red;
        }
    }
}
