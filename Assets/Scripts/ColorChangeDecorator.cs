using UnityEngine;

public class ColorChangeDecorator : CubeDecorator
{
    private Color _color;

    public ColorChangeDecorator(ICube cube, Color color) : base(cube)
    {
        _color = color;
    }

    public override void ApplyBehavior()
    {
        base.ApplyBehavior();
        _cube.GetTransform().GetComponent<Renderer>().material.color = _color;
        Debug.Log($"Cube color changed to {_color}");
    }
}
