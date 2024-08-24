using UnityEngine;

public class CubeBase : MonoBehaviour, ICube
{
    public void ApplyBehavior()
    {
        Debug.Log("Basic Cube behavior.");
    }

    public Transform GetTransform()
    {
        return transform; // Return the transform of the GameObject
    }
}
