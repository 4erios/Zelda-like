using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacing : MonoBehaviour
{
    public BoolVariable FacingRight;
    public BoolVariable FacingLeft;
    public BoolVariable FacingUp;
    public BoolVariable FacingDown;

    public void FaceRight()
    {
        FacingRight.SetBoolValue(true);
    }

    public void StopFaceRight()
    {
        FacingRight.SetBoolValue(false);
    }

    public void FaceLeft()
    {
        FacingLeft.SetBoolValue(true);
    }

    public void StopFaceLeft()
    {
        FacingLeft.SetBoolValue(false);
    }

    public void FaceUp()
    {
        FacingUp.SetBoolValue(true);
    }

    public void StopFaceUp()
    {
        FacingUp.SetBoolValue(false);
    }

    public void FaceDown()
    {
        FacingDown.SetBoolValue(true);
    }

    public void StopFaceDown()
    {
        FacingDown.SetBoolValue(false);
    }
}
