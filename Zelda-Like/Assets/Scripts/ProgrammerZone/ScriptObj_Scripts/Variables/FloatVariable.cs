// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;


[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float Value;

    public void SetFloatValue(float floatvalue)
    {
        Value = floatvalue;
    }
    public void SetFloatValue(FloatVariable floatvalue)
    {
        Value = floatvalue.Value;
    }

    public void ApplyChangeToFloat(float floatamount)
    {
        Value += floatamount;
    }
    public void ApplyChangeToFloat(FloatVariable floatamount)
    {
        Value += floatamount.Value;
    }

    public float value
    {
        get { return Value; }
    }

    public static implicit operator float(FloatVariable floatVariable) 
    {
        return floatVariable.Value;
    }
}

