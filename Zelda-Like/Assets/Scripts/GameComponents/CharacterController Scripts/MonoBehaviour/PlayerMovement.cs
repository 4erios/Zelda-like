using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Démarrage
    public static PlayerMovement manager;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    #endregion

    public Rigidbody2D rb; 

    public FloatVariable MoveX;
    public FloatVariable MoveY;

    private float moveX;
    private float moveY;

    public VectorVariable PlayerDirection;
    private Vector2 playerdirection;

    public FloatVariable CurrentSpeed;

    public FloatReference PlayerMaxSpeed;
    public FloatVariable PlayerSpeed;

    public AnimationCurve accelerationCurve;

    private void Start()
    {
        CurrentSpeed.SetFloatValue(PlayerMaxSpeed);
    }

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
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        playerdirection = new Vector2 (moveX, moveY);
        CurrentSpeed.SetFloatValue(Mathf.Clamp(playerdirection.magnitude, 0.0f, 1.0f));
        playerdirection.Normalize();
    }

    public void PlayerMove()
    {
        rb.velocity = playerdirection * PlayerSpeed * CurrentSpeed * accelerationCurve.Evaluate(Time.time);
    }

    public void SetSpeedToZero()
    {
        PlayerSpeed.SetFloatValue(0);
    }

    public void SetSpeedToMaxSpeed()
    {
        PlayerSpeed.SetFloatValue(PlayerMaxSpeed);
    }

    public void SetVelocityToZero()
    {
        rb.velocity = Vector2.zero;
    }
}
