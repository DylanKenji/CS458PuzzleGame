using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectHome : MonoBehaviour
{
    public float floatHeight = 0.5f;
    public float floatSpeed = 1f;
    public float spinSpeed = 50f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}