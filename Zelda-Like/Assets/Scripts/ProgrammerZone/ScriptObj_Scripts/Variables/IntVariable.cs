﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
    public int intValue;

    public void SetIntValue(int intvalue)
    {
        intValue = intvalue;
    }

    public void SetIntValue(IntVariable intvalue)
    {
        intValue = intvalue.intValue;
    }

    public void ApplyChangeToInt(int intamount)
    {
        intValue += intamount;
    }

    public void ApplyChangeToInt(IntVariable intamount)
    {
        intValue += intamount.intValue;
    }

    public float value
    {
        get { return intValue; }
    }

    public static implicit operator int(IntVariable intVariable)
    {
        return intVariable.intValue;
    }
}
