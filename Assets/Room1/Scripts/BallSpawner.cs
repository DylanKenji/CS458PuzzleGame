using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public float spawnInterval = 1f;
    public float spawnDuration = 20f;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);

   
        while (spawnDuration > 0)
        {
            GameObject randomPrefab = ballPrefabs[Random.Range(0, ballPrefabs.Length)];


            GameObject newBall = Instantiate(randomPrefab, transform.position, Quaternion.identity);

            Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 randomDirection = Random.onUnitSphere;
                float randomSpeed = Random.Range(minSpeed, maxSpeed);
                ballRigidbody.velocity = randomDirection * randomSpeed;
            }

            yield return new WaitForSeconds(spawnInterval);

            spawnDuration -= spawnInterval;
        }
    }
}


