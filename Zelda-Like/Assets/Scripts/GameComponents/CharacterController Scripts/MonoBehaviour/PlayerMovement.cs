using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public FloatVariable MoveX;
    public FloatVariable MoveY;

    public FloatReference PlayerSpeed;

    public AnimationCurve accelerationCurve;

    private void Update()
    {
        MoveX.SetFloatValue(Input.GetAxis("Horizontal"));
        MoveY.SetFloatValue(Input.GetAxis("Vertical"));
        PlayerAccelerate();


    }

    public void PlayerAccelerate()
    {
        rb.velocity = new Vector2(MoveX * accelerationCurve.Evaluate(Time.time), MoveY * accelerationCurve.Evaluate(Time.time)).normalized * PlayerSpeed;
    }


    public void PlayerMove()
    {
        rb.velocity = new Vector2(MoveX, MoveY).normalized * PlayerSpeed;
    }
}
