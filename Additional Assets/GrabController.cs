using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class ObjectGrabber : MonoBehaviour
{
    private InputDevice targetDevice;
    private GameObject grabbedObject;
    private Vector3 grabbedObjectOffset;

    void Start()
    {
        InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Left;
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var device in devices)
        {
            if (device.name.Contains("Oculus"))
            {
                targetDevice = device;
                break;
            }
        }

        if (targetDevice == null)
        {
            Debug.LogError("Oculus Quest 2 controller not found.");
        }
    }

    void Update()
    {
        if (targetDevice == null)
            return;

        // Detect trigger button press
        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue) && triggerButtonValue)
        {
            // If not already holding an object, try to grab one
            if (grabbedObject == null)
            {
                GrabObject();
            }
            else // If holding an object, move it
            {
                MoveObject();
            }
        }
        else // If trigger button is released, release the object
        {
            ReleaseObject();
        }
    }

    void GrabObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Grabbable"))
            {
                grabbedObject = hit.collider.gameObject;
                grabbedObjectOffset = grabbedObject.transform.position - transform.position;
            }
        }
    }

    void MoveObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = transform.position + grabbedObjectOffset;
        }
    }

    void ReleaseObject()
{
    if (grabbedObject != null)
    {
        Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calculate velocity based on the difference in position over time
            Vector3 velocity = (transform.position - grabbedObject.transform.position) / Time.deltaTime;
            rb.velocity = velocity;

            // Calculate angular velocity based on the difference in rotation over time
            Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(grabbedObject.transform.rotation);
            rb.angularVelocity = (new Vector3(deltaRotation.x, deltaRotation.y, deltaRotation.z)) / Time.deltaTime;
        }
        grabbedObject = null;
    }
}

}


