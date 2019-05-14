using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolVariable : ScriptableObject
{
    public bool boolValue;

    public void SetBoolValue(bool boolvalue)
    {
        boolValue = boolvalue;
    }

    public void SetBoolValue(BoolVariable boolvalue)
    {
        boolValue = boolvalue.boolValue;
    }

    public bool boolvalue
    {
        get { return boolValue; }
    }

    public static implicit operator bool(BoolVariable boolVariable)
    {
        return boolVariable.boolValue;
    }
}
