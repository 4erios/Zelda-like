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
    public SpriteRenderer enemySprite;

    [Header ("Beetle Stats")]
    public FloatReference beetleHealth;
    public FloatReference beetleSpeed;
    public FloatReference beetleAttackRange;
    public FloatReference beetleChargeSpeed;

    private Vector2 direction;

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
        
        if (playerInAttackRange && attackReady)
        {
            enemyAnimator.SetTrigger("InAttackRange");
        }

        enemyAnimator.SetFloat("Health", health);

        LaunchTakeDamagesAnimation();
    }

    public void BeetleSearchForPlayer()
    {
        PlayerDetection(enemyTransform, DetectionRange, playerLayer);
    }

    public void BeetleMoveToPlayer()
    {
        if (Vector2.Distance(playerTransform.position, enemyTransform.position) > beetleAttackRange)
        {
            MoveToPlayer(playerTransform, beetleSpeed);
        }
    }

    public void BeetleEnterAttackRange()
    {
        EnterAttackRange(enemyTransform, playerTransform, beetleAttackRange);
    }


    public void SetBeetleChargeDirection()
    {
        direction = (playerTransform.position - enemyTransform.position).normalized;
    }

    public void BeetleCharge()
    {
        enemyRb.velocity = new Vector2(direction.x * beetleChargeSpeed, direction.y * beetleChargeSpeed);
    }

    public void SetBeetleVelocityToZero()
    {
        SetVelocityToZero(enemyRb);
    }

    public void LaunchTakeDamagesAnimation()
    {
        if (takeDamages)
        {
            enemyAnimator.SetTrigger("TakeDamages");
        }
    }
}
