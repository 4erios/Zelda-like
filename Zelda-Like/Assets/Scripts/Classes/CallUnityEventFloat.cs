using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallUnityEventFloat : MonoBehaviour
{
    public UnityEventFloat eventfloat;

    void ProcessValue(float v)
    {
        if (eventfloat != null)
        {
            eventfloat.Invoke(v);
        }
    }
}
