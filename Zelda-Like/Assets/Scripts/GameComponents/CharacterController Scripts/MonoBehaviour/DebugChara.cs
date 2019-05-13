using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChara : MonoBehaviour
{
    public string DebugMessage;

    public void CallDebugMessage()
    {
        Debug.Log(DebugMessage);
    }
}
