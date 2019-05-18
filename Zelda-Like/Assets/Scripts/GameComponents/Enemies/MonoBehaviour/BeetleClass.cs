using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleClass : EnemyClass
{
    [Header("Beetle Detection Parameters")]
    public FloatReference DetectionRange;
    public LayerMask playerLayer;

    [Header("Beetle Components")]
    public Animator enemyAnimator;
    public Transform enemyTransform;
    public SpriteRenderer enemySprite;
    public Rigidbody2D enemyRb;

    [Header ("Beetle Stats")]
    public FloatReference beetleHealth;
    public FloatReference beetleSpeed;
    public FloatReference beetleAttackRange;
    public FloatReference beetleChargeSpeed;

    private void Start()
    {
        //initialise enemyHp
        health = beetleHealth;
    }

    private void Update()
    {
        FacePlayer(playerTransform, enemySprite);
        
        if (playerDetected)
        {
            enemyAnimator.SetTrigger("PlayerDetected");
        }
        
        if (playerInAttackRange)
        {
            enemyAnimator.SetTrigger("InAttackRange");
        }
    }

    public void BeetleSearchForPlayer()
    {
        PlayerDetection(enemyTransform, DetectionRange, playerLayer);
    }

    public void BeetleMoveToPlayer()
    {
        MoveToPlayer(playerTransform, beetleSpeed);
    }

    public void BeetleEnterAttackRange()
    {
        EnterAttackRange(enemyTransform, playerTransform, beetleAttackRange);
    }

    public void BeetleCharge()
    {
        Vector2 direction = new Vector2 (enemyTransform.position.x + playerTransform.position.x, enemyTransform.position.y + playerTransform.position.y).normalized;
        enemyRb.velocity = new Vector2(direction.x * beetleChargeSpeed, direction.y * beetleChargeSpeed);
    }

    public void SetBeetleVelocityToZero()
    {
        SetVelocityToZero(enemyRb);
    }
}
