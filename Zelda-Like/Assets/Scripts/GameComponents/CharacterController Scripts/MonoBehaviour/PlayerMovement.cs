using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public FloatVariable MoveX;
    public FloatVariable MoveY;

    public VectorVariable PlayerDirection;
    private Vector2 playerdirection;

    public FloatVariable CurrentSpeed;

    public FloatReference PlayerSpeed;

    public AnimationCurve accelerationCurve;

    private void Update()
    {
        ProcessInputs();
        PlayerDirection.SetVector(playerdirection);
    }

    public void ProcessInputs()
    {
        MoveX.SetFloatValue(Input.GetAxis("Horizontal"));
        MoveY.SetFloatValue(Input.GetAxis("Vertical"));
        playerdirection = new Vector2 (MoveX, MoveY);
        CurrentSpeed.SetFloatValue(Mathf.Clamp(playerdirection.magnitude, 0.0f, 1.0f));
        playerdirection.Normalize();
    }

    public void PlayerMove()
    {
        rb.velocity = playerdirection * CurrentSpeed * PlayerSpeed * accelerationCurve.Evaluate(Time.time);
    }
}
