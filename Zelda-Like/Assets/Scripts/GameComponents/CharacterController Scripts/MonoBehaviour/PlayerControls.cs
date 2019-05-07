using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("InputSettings")]
    public string NameInputButtonA;
    public string NameInputButtonX;
    public string NameInputButtonY;
    public string NameInputButtonB;
    public string NameInputRightBumper;
    public string NameInputLeftBumper;
    public string NameInputRightTrigger;
    public string NameInputLeftTrigger;

    [Header("InputEvents")]
    public GameEvent PressA;
    public GameEvent PressX;
    public GameEvent PressY;
    public GameEvent PressB;
    public GameEvent PressRightBumper;
    public GameEvent PressLeftBumper;
    public GameEvent PressRightTrigger;
    public GameEvent PressLeftTrigger;


    private void Update()
    {
        if (Input.GetButton(NameInputButtonA))
            PressA.Raise();

        if (Input.GetButton(NameInputButtonX))
            PressX.Raise();

        if (Input.GetButton(NameInputButtonY))
            PressY.Raise();

        if (Input.GetButton(NameInputButtonB))
            PressB.Raise();

        if (Input.GetButton(NameInputRightBumper))
            PressRightBumper.Raise();

        if (Input.GetButton(NameInputLeftBumper))
            PressLeftBumper.Raise();

    }

}
