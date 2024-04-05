using UnityEngine;

public class ColorChangingCube : MonoBehaviour
{
    private Renderer cubeRenderer;
    private Color[] colors = { Color.blue, Color.yellow, Color.green, Color.red };
    private int currentIndex = 0;
    private ScoreManager scoreManager;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        scoreManager = FindObjectOfType<ScoreManager>();
        UpdateCubeColor();
    }

    public void ChangeColor()
    {
        currentIndex = (currentIndex + 1) % colors.Length;
        UpdateCubeColor();
    }

    private void UpdateCubeColor()
    {
        cubeRenderer.material.color = colors[currentIndex];
        scoreManager.SetCurrentColor(colors[currentIndex]); // Set the current color directly in ScoreManager
    }

    // Added method to retrieve the current color index
    public int GetCurrentColorIndex()
    {
        return currentIndex;
    }
}
