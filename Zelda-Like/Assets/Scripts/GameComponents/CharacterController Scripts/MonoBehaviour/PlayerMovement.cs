using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public FloatVariable moveX;
    public FloatVariable moveY;

    public FloatReference PlayerSpeed;

    public AnimationCurve accelerationCurve;

    private void Update()
    {
        moveX.SetFloatValue(Input.GetAxis("Horizontal"));
        moveY.SetFloatValue(Input.GetAxis("Vertical"));
    }

    public void PlayerAccelerate()
    {
        rb.velocity = new Vector2(moveX * accelerationCurve.Evaluate(Time.time), moveY * accelerationCurve.Evaluate(Time.time)).normalized * PlayerSpeed;
    }


    public void PlayerMove()
    {
        rb.velocity = new Vector2(moveX, moveY).normalized * PlayerSpeed;
    }
}
