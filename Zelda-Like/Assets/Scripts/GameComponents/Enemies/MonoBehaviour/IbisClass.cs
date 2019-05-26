using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbisClass : EnemyClass
{
    [Header("Ibis Detection Parameters")]
    public FloatReference DetectionRange;
    public LayerMask playerLayer;

    [Header("Ibis Components")]
    public Animator enemyAnimator;
    public SpriteRenderer enemySprite;
    public Rigidbody2D projectileToInstantiate;
    public Transform ShootingPoint;

    [Header("Ibis Stats")]
    public FloatReference IbisHealth;
    public FloatReference IbisSpeed;
    public FloatReference IbisMeleeAttackRange;
    public FloatReference IbisDistanceAttackRange;
    public FloatReference IbisBulletSpeed;

    private void Start()
    {
        health = IbisHealth;
    }

    private void Update()
    {

    }

    public void IbisSearchForPlayer()
    {
        PlayerDetection(enemyTransform, DetectionRange, playerLayer);
    }

    public void IbisMoveToPlayer()
    {
        MoveToPlayer(playerTransform, IbisSpeed);
    }

    public void IbisEnterMeleeAttackRange()
    {

    }

    public void IbisEnterDistanceAttackRange()
    {

    }

    public void SetIbisVelocityToZero()
    {

    }

    public void LaunchTakeDamagesAnimation()
    {

    }
}
