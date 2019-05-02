using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Made after Ryan Hipple Scriptable Object System presented at the 2017 GDC Unity Conference

[Serializable]
public class IntReferences 
{
    public bool UseConstant = true;
    public int ConstantValue;
    public IntVariable Variable;

    public IntReferences()
    { }

    public IntReferences(int value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.intValue; }
    }

    public static implicit operator int (IntReferences reference)
    {
        return reference.Value;
    }
}
