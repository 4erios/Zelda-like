using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : LivingClass
{
    //PlayerDetection - Done
    //FacePlayer - In Progress
    //MoveToPlayer - Done
    //KnockBack - To Do
    //MessageSystem - To Do

    private bool playerDetected = false;

    public void PlayerDetection(Transform monsterPosition, float detectionRange, LayerMask playerLayer)
    {
        Collider2D detection = Physics2D.OverlapCircle(monsterPosition.position, detectionRange, playerLayer);
        if (detection != null)
        {
            playerDetected = true;
        }
    }

    public void MoveToPlayer(Transform playerPosition, float speed, float stopRange)
    {
        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.position, speed * Time.deltaTime);
    }

    public void FacePlayer(Transform playerPosition)
    {
        if (this.transform.position.x < playerPosition.position.x)
        {
            //FacingRight
        }
        else if (this.transform.position.x > playerPosition.position.x)
        {
            //FacingLeft
        }
    }

    public void EnterAttackRange(float attackRange)
    {
        if ()
        {

        }
    }

}
