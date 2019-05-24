using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : LivingClass
{
    [Header("Ennemies Basic Components")]
    public Transform playerTransform;
    public bool playerDetected = false;
    public bool playerInAttackRange = false;
    public bool attackReady = true;
    public FloatReference TimeBetweenAttacks;
    public Rigidbody2D enemyRb;
    public Transform enemyTransform;
    public FloatReference knockbackDistance;

    private Vector2 direction;


    public void PlayerDetection(Transform monsterPosition, float detectionRange, LayerMask playerLayer)
    {
        Collider2D detection = Physics2D.OverlapCircle(monsterPosition.position, detectionRange, playerLayer);
        if (detection != null)
        {
            playerDetected = true;
            Debug.Log("player found");
        }
    }

    public void MoveToPlayer(Transform playerPosition, float currentspeed)
    {
        Vector2 direction = (playerTransform.position - enemyTransform.position).normalized;
        enemyRb.velocity = new Vector2(direction.x * currentspeed, direction.y * currentspeed);
    }

    public void FacePlayer(Transform playerPosition, SpriteRenderer enemySprite)
    {
        if (this.transform.position.x > playerPosition.position.x)
        {
            if(enemySprite.flipX == true)
            {
                enemySprite.flipX = false;
            }
        }
        else if (this.transform.position.x < playerPosition.position.x)
        {
            if (enemySprite.flipX == false)
            {
                enemySprite.flipX = true;
            }
        }
    }

    public void SetKnockBackDirection()
    {
        direction = enemyTransform.position - playerTransform.position;
    }

    public void KnockBack()
    {
        enemyRb.velocity = (direction.normalized * knockbackDistance); 
    }

    public void EnterAttackRange(Transform enemyPosition, Transform playerPosition,float attackRange)
    {
        if (Vector2.Distance(enemyPosition.position, playerPosition.position) <= attackRange)
        {
            playerInAttackRange = true;
        }
        else
        {
            playerInAttackRange = false;
        }
    }

    public void SetVelocityToZero(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }

    public IEnumerator DelayBetweenAttacks()
    {
        yield return new WaitForSeconds(TimeBetweenAttacks);
        attackReady = true;
        Debug.Log("AttackCDDone");

    }

    public void LaunchDelayBetweenAttacks()
    {
        attackReady = false;
        Debug.Log("LaunchAttackDelay");
        StartCoroutine("DelayBetweenAttacks");
    }
}
