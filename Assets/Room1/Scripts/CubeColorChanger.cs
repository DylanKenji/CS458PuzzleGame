using UnityEngine;
using System.Collections;

public class CubeColorChanger : MonoBehaviour
{
    public Material[] colors; // Array of cube materials (yellow, green, red, blue)
    public Renderer cubeRenderer;
    public float colorDuration = 10f; // Duration of each color

    private int currentIndex = 0; // Index of the current color

    void Start()
    {
        // Start cycling through colors
        StartCoroutine(ChangeColorRepeatedly());
    }

    IEnumerator ChangeColorRepeatedly()
    {
        while (true)
        {
            // Change to the next color
            ChangeCubeColor();
            
            // Wait for the specified color duration
            yield return new WaitForSeconds(colorDuration);
        }
    }

    void ChangeCubeColor()
    {
        // Apply the current color to the cube
        cubeRenderer.material = colors[currentIndex];

        // Increment the index to cycle through colors
        currentIndex = (currentIndex + 1) % colors.Length;
    }
}
