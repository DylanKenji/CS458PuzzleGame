using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material skyboxForPlane1;
    public Material skyboxForPlane2;
    public Material skyboxForPlane3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane1"))
        {
            RenderSettings.skybox = skyboxForPlane1;
        }
        else if (other.CompareTag("Plane2"))
        {
            RenderSettings.skybox = skyboxForPlane2;
        }
        else if (other.CompareTag("Plane3"))
        {
            RenderSettings.skybox = skyboxForPlane3;
        }
    }
}
