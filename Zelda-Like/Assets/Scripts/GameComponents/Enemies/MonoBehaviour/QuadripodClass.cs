using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadripodClass : EnemyClass
{
    [Header("Quadripod Detection Parameters")]
    public FloatReference DetectionRange;
    public LayerMask playerLayer;

    [Header("Quadripod Components")]
    public Animator enemyAnimator;
    public SpriteRenderer enemySprite;
    public Rigidbody2D projectileToInstantiate;
    public Transform ShootingPoint;

    [Header("Quadripod Stats")]
    public FloatReference quadripodHealth;
    public FloatReference quadripodSpeed;
    public FloatReference quadripodAttackRange;
    public FloatReference quadripodBulletSpeed;


    private void Start()
    {
        health = quadripodHealth;
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
    }

    public void QuadripodSearchForPlayer()
    {
        PlayerDetection(enemyTransform, DetectionRange, playerLayer);
    }

    public void QuadripodMoveToPlayer()
    {
        if(Vector2.Distance(playerTransform.position, enemyTransform.position) > quadripodAttackRange)
        {
            MoveToPlayer(playerTransform, quadripodSpeed);
        }
    }

    public void QuadripodEnterAttackRange()
    {
        EnterAttackRange(enemyTransform, playerTransform, quadripodAttackRange);
    }

    public void QuadripodShoot()
    {
        Vector2 direction = (ShootingPoint.position - enemyTransform.position).normalized;
        Rigidbody2D clone;
        clone = Instantiate(projectileToInstantiate, ShootingPoint.position, ShootingPoint.rotation);
        clone.velocity = direction * quadripodBulletSpeed;
    }

    public void SetQuadripodVelocityToZero()
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
