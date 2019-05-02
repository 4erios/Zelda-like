using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameEvent PressA;
    public GameEvent PressRightTrigger;

    public void OnPressA()
    {
        PressA.Raise();
    }

    public void OnRightTrigger()
    {
        PressRightTrigger.Raise();
    }
}
