using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : LivingClass
{
    public void PlayerMove(Rigidbody2D rb,float moveX, float moveY,float speed, AnimationCurve accelerationCurve)
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX*speed* accelerationCurve.Evaluate(Time.time), moveY * speed * accelerationCurve.Evaluate(Time.time));
    }


    public void PlayerFirstAttack()
    {

    }

    public void PlayerSecondAttack()
    {

    }

    public void PlayerThirdAttack()
    {

    }
}
