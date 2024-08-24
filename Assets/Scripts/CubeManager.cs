using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private void Start()
    {
        // Find the CubeBase GameObject in the scene
        ICube cube = FindObjectOfType<CubeBase>();

        // Apply decorators
        cube = new ScaleDecorator(cube, 1.5f);
        cube = new RotateDecorator(cube, 225f);
        cube = new ColorChangeDecorator(cube, Color.red);

        // Apply all behaviors
        cube.ApplyBehavior();
    }
}
