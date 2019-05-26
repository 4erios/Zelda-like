using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorVariable : ScriptableObject
{
    public Vector2 Vector2;

    public void SetVector(Vector2 vector2)
    {
        Vector2 = vector2;
    }

    public void SetVector(VectorVariable vectorVariable)
    {
        Vector2 = vectorVariable.Vector2;
    }

    public Vector2 vector2
    {
        get { return Vector2; }
    }

    public static implicit operator Vector2(VectorVariable vectorVariable)
    {
        return vectorVariable.Vector2;
    }
}
