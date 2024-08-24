# Unity Decorator Pattern Example

This Unity project demonstrates the use of the **Decorator** design pattern. The Decorator pattern allows you to dynamically add behaviors to objects by wrapping them in decorator classes.

## Project Overview

In this project, we have a `CubeBase` class that implements the `ICube` interface. The base cube behavior can be enhanced by using various decorators like `ScaleDecorator`, `RotateDecorator`, and `ColorChangeDecorator`.

### Components

- **ICube Interface**: Defines the structure for cube behaviors, including the `ApplyBehavior` method and the `GetTransform` method for accessing the `Transform` component.

```csharp
using UnityEngine;

public interface ICube
{
    void ApplyBehavior();
    Transform GetTransform(); // Allows decorators to access the Transform
}
```

- **CubeBase Class**: Implements the `ICube` interface and provides the basic behavior for the cube.

```csharp
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
```

- **CubeDecorator Abstract Class**: Serves as a base class for all decorators. It implements the `ICube` interface and wraps another `ICube` instance, allowing additional behaviors to be layered.

```csharp
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
```

- **ScaleDecorator Class**: A concrete decorator that scales the cube by a specified factor.

```csharp
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
```

- **RotateDecorator Class**: A concrete decorator that rotates the cube by a specified angle.

```csharp
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
        _cube.GetTransform().Rotate(Vector3.up, _rotationAngle);
        Debug.Log($"Cube rotated by {_rotationAngle} degrees.");
    }
}
```

- **ColorChangeDecorator Class**: A concrete decorator that changes the color of the cube.

```csharp
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
```

- **CubeManager Class**: Manages the application of decorators to the cube. It finds the CubeBase object in the scene and applies the decorators in sequence.

```csharp
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
```  
   
