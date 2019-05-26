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
    public GameObject EnemyToInstantiate;
    public Transform SpawnSpitPoint;

    [Header("Ibis Stats")]
    public FloatReference IbisHealth;
    public FloatReference IbisSpeed;
    public FloatReference IbisMeleeAttackRange;
    public FloatReference IbisDistanceAttackRange;
    public FloatReference IbisBulletSpeed;
    public FloatReference BeetleSpawnCouldown;

    public bool canSpawnBeetles = true;
    public bool canAttackInMelee = false;

    private void Start()
    {
        health = IbisHealth;
    }

    private void Update()
    {
        FacePlayer(playerTransform, enemySprite);

        if (playerDetected)
        {
            enemyAnimator.SetTrigger("PlayerDetected");
        }

        enemyAnimator.SetFloat("Health", health);

        enemyAnimator.SetBool("PlayerInAttackRange", playerInAttackRange);
        enemyAnimator.SetBool("AttackReady", attackReady);
        enemyAnimator.SetBool("SpawnBeetle",canSpawnBeetles);
        enemyAnimator.SetBool("MeleeAttack", canAttackInMelee);

        LaunchTakeDamagesAnimation();
    }

    public void ShootAcidSpray()
    {
        Vector2 direction = (playerTransform.position - ShootingPoint.position).normalized;
        Rigidbody2D clone;
        clone = Instantiate(projectileToInstantiate, ShootingPoint.position, ShootingPoint.rotation);
        clone.velocity = direction * IbisBulletSpeed;
    }

    public void SpawnBeetles()
    {
        GameObject beetleClone;
        beetleClone = Instantiate(EnemyToInstantiate, SpawnSpitPoint.position, SpawnSpitPoint.rotation);
    }

    public void IbisSearchForPlayer()
    {
        PlayerDetection(enemyTransform, DetectionRange, playerLayer);
    }

    public void IbisMoveToPlayer()
    {
        MoveToPlayer(playerTransform, IbisSpeed);
    }

    public void IbisEnterAttackRange()
    {
        EnterAttackRange(enemyTransform, playerTransform, IbisDistanceAttackRange);
    }

    public void IbisEnterMeleeAttackRange()
    {
        if (Vector2.Distance(enemyTransform.position, playerTransform.position) <= IbisMeleeAttackRange)
        {
            canAttackInMelee = true;
        }
        else
        {
            canAttackInMelee = false;
        }
    }

    public void SetIbisVelocityToZero()
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

    public IEnumerator DelayBetweenBeetlesSpawn()
    {
        yield return new WaitForSeconds(BeetleSpawnCouldown);
        canSpawnBeetles = true;
    }

    public void LaunchDelayBetweenBeetlesSpawn()
    {
        StartCoroutine("DelayBetweenBeetlesSpawn");
    }

    public void StopBeetlesSpawns()
    {
        canSpawnBeetles = false;
    }

    public void StopDelayBetweenBeetlesSpawn()
    {
        StopCoroutine("DelayBetweenBeetlesSpawn");
    }
}
