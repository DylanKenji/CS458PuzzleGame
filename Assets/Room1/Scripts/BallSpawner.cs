using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] ballPrefabs; // Array of ball prefabs
    public float spawnInterval = 1f; // Interval between spawns
    public float spawnDuration = 20f; // Duration of spawning
    public float minSpeed = 1f; // Minimum speed of the spawned balls
    public float maxSpeed = 3f; // Maximum speed of the spawned balls

    IEnumerator Start()
    {
        // Wait for 20 seconds before starting spawning
        yield return new WaitForSeconds(20f);

   
        while (spawnDuration > 0)
        {
            // Randomly select a prefab from the array
            GameObject randomPrefab = ballPrefabs[Random.Range(0, ballPrefabs.Length)];


            GameObject newBall = Instantiate(randomPrefab, transform.position, Quaternion.identity);

            // Apply random speed and direction to the new ball
            Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 randomDirection = Random.onUnitSphere; // Random direction
                float randomSpeed = Random.Range(minSpeed, maxSpeed); // Random speed
                ballRigidbody.velocity = randomDirection * randomSpeed;
            }

        
            yield return new WaitForSeconds(spawnInterval);

            // Deduct the spawn interval from the remaining duration
            spawnDuration -= spawnInterval;
        }
    }
}


