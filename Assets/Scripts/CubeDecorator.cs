using UnityEngine;
public abstract class CubeDecorator : ICube
{
    protected ICube _cube;

    public CubeDecorator(ICube cube)
    {
        _cube = cube;  
    }

    public virtual void ApplyBehavior()
    {
        _cube.ApplyBehavior();
    }

    public Transform GetTransform()
    {
        return _cube.GetTransform(); // Forward the Transform call to the wrapped component
    }
}
