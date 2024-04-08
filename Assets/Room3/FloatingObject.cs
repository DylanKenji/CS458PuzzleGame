using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script just adds a floating/spinning look to an object that it's attached to.
// You can also customize the floating height, speed, and spin in the inspection parameters

public class FloatingObject : MonoBehaviour
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