using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleStateManager : EnemyClass
{
    public FloatReference beetleHealth;

    public FloatReference beetleSpeed;

    public Transform beetleTarget;

    public LayerMask playerLayer;

    public Animator enemyAnimator;


    private void Start()
    {
        //initialise enemyHp
        health = beetleHealth;
    }

    private void Update()
    {
        
    }
}
