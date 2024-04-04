using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls; // Array of ball prefabs
    public float spawnInterval = 1f; // Interval between spawns
    public float spawnDuration = 20f; // Duration of spawning
    public float minSpeed = 1f; // Minimum speed of the spawned balls
    public float maxSpeed = 3f; // Maximum speed of the spawned balls

    IEnumerator Start()
    {
        // Continue spawning balls until spawn duration runs out
        while (spawnDuration > 0)
        {
            // Randomly select a ball prefab from the array
            GameObject ballPrefab = balls[Random.Range(0, balls.Length)];
            
            // Instantiate the selected ball at the spawner's position
            GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            
            // Apply random speed and direction to the new ball
            Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 randomDirection = Random.onUnitSphere; // Random direction
                float randomSpeed = Random.Range(minSpeed, maxSpeed); // Random speed
                ballRigidbody.velocity = randomDirection * randomSpeed;
            }

            // Wait for the specified spawn interval before spawning the next ball
            yield return new WaitForSeconds(spawnInterval);
            
            // Deduct the spawn interval from the remaining duration
            spawnDuration -= spawnInterval;
        }
    }
}

