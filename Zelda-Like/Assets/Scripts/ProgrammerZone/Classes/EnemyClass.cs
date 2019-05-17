using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : LivingClass
{
    //PlayerDetection - Done
    //FacePlayer - Done
    //MoveToPlayer - Done
    //KnockBack - To Do

    public bool playerDetected = false;
    public bool playerInAttackRange = false;

    public void PlayerDetection(Transform monsterPosition, float detectionRange, LayerMask playerLayer)
    {
        Collider2D detection = Physics2D.OverlapCircle(monsterPosition.position, detectionRange, playerLayer);
        if (detection != null)
        {
            playerDetected = true;
        }
    }

    public void MoveToPlayer(Transform playerPosition, float currentspeed)
    {
        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.position, currentspeed * Time.deltaTime);
    }

    public void FacePlayer(Transform playerPosition, SpriteRenderer enemySprite)
    {
        if (this.transform.position.x < playerPosition.position.x)
        {
            if(enemySprite.flipX == true)
            {
                enemySprite.flipX = false;
            }
        }
        else if (this.transform.position.x > playerPosition.position.x)
        {
            if (enemySprite.flipX == false)
            {
                enemySprite.flipX = true;
            }
        }
    }

    public void KnockBack()
    {

    }

    public void EnterAttackRange(Transform playerPosition,float attackRange)
    {
        if (Vector2.Distance(this.transform.position, playerPosition.position) >= attackRange)
        {
            playerInAttackRange = true;
        }
        else
        {
            playerInAttackRange = false;
        }
    }

    public void SetCurrentSpeedToZero(float currentSpeed)
    {
        currentSpeed = 0;
    }

    public void SetCurrentSpeedToSpeed(float currentSpeed, float speed)
    {
        currentSpeed = speed;
    }

}
