using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public FloatVariable MoveX;
    public FloatVariable MoveY;

    private float moveX;
    private float moveY;

    public VectorVariable PlayerDirection;
    private Vector2 playerdirection;

    public FloatVariable CurrentSpeed;

    public FloatReference PlayerSpeed;

    public AnimationCurve accelerationCurve;

    private void Update()
    {
        ProcessInputs();
        PlayerDirection.SetVector(playerdirection);

        //allow the player to keep his last position
        if (PlayerDirection != Vector2.zero)
        {
            MoveX.SetFloatValue(moveX);
            MoveY.SetFloatValue(moveY);
        }
    }

    public void ProcessInputs()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        playerdirection = new Vector2 (moveX, moveY);
        CurrentSpeed.SetFloatValue(Mathf.Clamp(playerdirection.magnitude, 0.0f, 1.0f));
        playerdirection.Normalize();
    }

    public void PlayerMove()
    {
        rb.velocity = playerdirection * CurrentSpeed * PlayerSpeed * accelerationCurve.Evaluate(Time.time);
    }
}
