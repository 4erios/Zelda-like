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

        }

        if (playerInAttackRange && attackReady)
        {

        }
    }
}
