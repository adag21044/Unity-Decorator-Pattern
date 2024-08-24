using UnityEngine;

public interface ICube
{
    void ApplyBehavior();
    Transform GetTransform(); // Allows decorators to access the Transform
}
