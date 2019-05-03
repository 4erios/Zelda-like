using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public FloatVariable moveX;
    public FloatVariable moveY;

    public FloatReference PlayerSpeed;

    private void Update()
    {
        PlayerMove(rb, moveX, moveY, PlayerSpeed); 
        
    }

    public void PlayerAccelerate(Rigidbody2D rb, FloatVariable moveX, FloatVariable moveY, float speed, AnimationCurve accelerationCurve)
    {
        moveX.SetFloatValue(Input.GetAxis("Horizontal"));
        moveY.SetFloatValue(Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(moveX * accelerationCurve.Evaluate(Time.time), moveY * accelerationCurve.Evaluate(Time.time)).normalized * speed;
    }


    public void PlayerMove(Rigidbody2D rb, FloatVariable moveX, FloatVariable moveY, float speed)
    {
        moveX.SetFloatValue( Input.GetAxis("Horizontal"));
        moveY.SetFloatValue(Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(moveX, moveY).normalized * speed;
    }
}
