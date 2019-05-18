using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleClass : EnemyClass
{
    [Header("Beetle Detection Parameters")]
    public FloatReference DetectionRange;
    public LayerMask playerLayer;
    public Transform beetleTarget;

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
        FacePlayer(beetleTarget, enemySprite);
        
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
        MoveToPlayer(beetleTarget, beetleSpeed);
    }

    public void BeetleEnterAttackRange()
    {
        EnterAttackRange(enemyTransform, beetleTarget, beetleAttackRange);
    }

    public void BeetleCharge()
    {
        Vector2 direction = enemyTransform.position + beetleTarget.position;
        enemyRb.AddForce(direction.normalized * beetleChargeSpeed);
    }
}
