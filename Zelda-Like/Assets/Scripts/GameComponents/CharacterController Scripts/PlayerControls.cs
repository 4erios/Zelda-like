using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameEvent PressX;
    public GameEvent PressRightTrigger;

    public void OnPressX()
    {
        PressX.Raise();
    }

    public void OnRightTrigger()
    {
        PressRightTrigger.Raise();
    }
}
