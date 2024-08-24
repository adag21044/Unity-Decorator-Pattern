using UnityEngine;

public class ScaleDecorator : CubeDecorator
{
    private float _scaleFactor;

    public ScaleDecorator(ICube cube, float scaleFactor) : base(cube)
    {
        _scaleFactor = scaleFactor;
    }

    public override void ApplyBehavior()
    {
        base.ApplyBehavior();
        _cube.GetTransform().localScale *= _scaleFactor;
        Debug.Log($"Cube scaled by {_scaleFactor}");
    }
}
