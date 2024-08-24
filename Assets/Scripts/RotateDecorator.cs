using UnityEngine;

public class RotateDecorator : CubeDecorator
{
    private float _rotationAngle = 45f;

    public RotateDecorator(ICube cube, float rotationAngle) : base(cube)
    {
        _rotationAngle = rotationAngle;
    }

    public override void ApplyBehavior()
    {
        base.ApplyBehavior();

        // Rotasyonu uygula (her seferinde sabit bir açı ekle)
        _cube.GetTransform().Rotate(Vector3.up, _rotationAngle);
        Debug.Log($"Cube rotated by {_rotationAngle} degrees.");
    }
}
