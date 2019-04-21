using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : LivingClass
{
    public void PlayerAccelerate(Rigidbody2D rb,float moveX, float moveY,float speed, AnimationCurve accelerationCurve)
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX*speed* accelerationCurve.Evaluate(Time.time), moveY * speed * accelerationCurve.Evaluate(Time.time));
    }

    public void PlayerMove(Rigidbody2D rb, float moveX, float moveY, float speed)
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX * speed, moveY * speed);
    }

    public void PlayerAttack(Transform AttackPoint, float attackRange,LayerMask enemiesLayer, float playerDamages)
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange);
        for (int i=0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(playerDamages);
            Debug.Log("Ennemi touché");
            Debug.Log(i);
        }
    }

}
