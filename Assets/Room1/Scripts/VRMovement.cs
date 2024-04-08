using UnityEngine;
using UnityEngine.XR;

public class VRMovement : MonoBehaviour
{
    public XRNode inputSource; 
    public float speed = 1.0f;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        Vector2 inputAxis;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis))
        {
            Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y).normalized;
            Vector3 moveDirection = transform.TransformDirection(direction) * speed * Time.deltaTime;

            // Move the controller in the calculated direction
            transform.position += moveDirection;
        }
    }
}
