using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private float moveX;
    private float moveY;

    public FloatReference PlayerSpeed;

    private void Update()
    {
        PlayerMove(rb, moveX, moveY, PlayerSpeed); 
    }

    public void PlayerAccelerate(Rigidbody2D rb, float moveX, float moveY, float speed, AnimationCurve accelerationCurve)
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX * accelerationCurve.Evaluate(Time.time), moveY * accelerationCurve.Evaluate(Time.time)).normalized * speed;
    }


    public void PlayerMove(Rigidbody2D rb, float moveX, float moveY, float speed)
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX, moveY).normalized * speed;
    }
}
