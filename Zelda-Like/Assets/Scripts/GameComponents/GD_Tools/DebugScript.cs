﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public string DebugMessage;

    public void CallDebugMessage()
    {
        Debug.Log(DebugMessage);
    }
}
