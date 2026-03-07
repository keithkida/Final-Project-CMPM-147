using UnityEngine;

public class MapColorizer : MonoBehaviour
{
    public SpriteRenderer[] wallRenderers;

    public Color[] wallColors;

    void Start()
    {
        // Pick random colors
        Color chosenWallColor = wallColors[Random.Range(0, wallColors.Length)];

        // Apply to all walls
        foreach (var w in wallRenderers)
            w.color = chosenWallColor;

    }
}
