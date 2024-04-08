using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int ballsCollected = 0; // Counter to track the number of balls collected

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a ball
        if (other.CompareTag("Ball"))
        {
            // Destroy the collected ball
            Destroy(other.gameObject);

            // Increment the balls collected counter
            ballsCollected++;
        }
    }
}

