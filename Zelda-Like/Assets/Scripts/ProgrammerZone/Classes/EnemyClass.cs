using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : LivingClass
{
    [Header("Ennemies Basic Components")]
    public Transform playerTransform;
    public bool playerDetected = false;
    public bool playerInAttackRange = false;

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

    public void KnockBack(Rigidbody2D enemyRigidbody,Transform playerPosition, float knockbackDistance)
    {
        Vector2 direction = this.transform.position - playerPosition.position;
        enemyRigidbody.AddForce(direction.normalized * knockbackDistance);
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

}
