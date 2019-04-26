/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;*/
using System;

[Serializable]
public class FloatReference 
{
    public bool useConstant = true;
    public float constantValue;
    public FloatVariable variable;

    public float value
    {
        get {return useConstant ? constantValue: variable.value;}
    }

}




/*public FloatReference (float value)
    {
        useConstant = true;
        constantValue = value;
    }*/

/*public static implicit operator float (FloatReference reference)
{
    return reference.value;
}*/
