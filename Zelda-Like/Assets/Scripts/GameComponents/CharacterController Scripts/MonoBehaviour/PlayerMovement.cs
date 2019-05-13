using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public FloatVariable MoveX;
    public FloatVariable MoveY;
    public Vector2 PlayerDirection;
    public FloatVariable CurrentSpeed;

    public FloatReference PlayerSpeed;

    public AnimationCurve accelerationCurve;

    private void Update()
    {
        ProcessInputs();

        //à foutre dans le state update après, placer ici pour permettre le test
        PlayerMove();

    }

    public void ProcessInputs()
    {
        MoveX.SetFloatValue(Input.GetAxis("Horizontal"));
        MoveY.SetFloatValue(Input.GetAxis("Vertical"));
        PlayerDirection = new Vector2 (MoveX, MoveY);
        CurrentSpeed.SetFloatValue(Mathf.Clamp(PlayerDirection.magnitude, 0.0f, 1.0f));
        PlayerDirection.Normalize();
    }

    public void PlayerMove()
    {
        rb.velocity = PlayerDirection * CurrentSpeed * PlayerSpeed * accelerationCurve.Evaluate(Time.time);
    }
}
