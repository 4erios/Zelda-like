﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    public FloatVariable MoveX;
    public FloatVariable MoveY;
    public FloatVariable CurrentSpeed;
    public VectorVariable PlayerDirection;

    public IntVariable AttackCount;

    void Update()
    {
        //allow the player to keep his last position
        if(PlayerDirection != Vector2.zero)
        {
            playerAnimator.SetFloat("MoveX", MoveX);
            playerAnimator.SetFloat("MoveY", MoveY);
        }

        playerAnimator.SetFloat("Speed", CurrentSpeed);
        playerAnimator.SetInteger("AttackCount", AttackCount);
    }

    public void LaunchAttackAnimation()
    {
        playerAnimator.SetTrigger("Attack");
        Debug.Log("Attack Animation");
    }

    public void LaunchDashAnimation()
    {
        playerAnimator.SetTrigger("Dash");
    }

    public void LaunchHealAnimation()
    {
        playerAnimator.SetBool("Heal", true);
    }

    public void StopHealAnimation()
    {
        playerAnimator.SetBool("Heal", false);
    }

    public void LaunchTakeDamageAnimation()
    {
        playerAnimator.SetTrigger("TakeDamage");
    }

    public void LaunchResurrectionAnimation()
    {
        playerAnimator.SetTrigger("Résurrection");
    }

    public void LaunchDeathAnimation()
    {
        playerAnimator.SetTrigger("Death");
    }

    public void LaunchShootAnimation()
    {
        playerAnimator.SetTrigger("Tir");
    }

    public void LaunchInsufflationAnimation()
    {
        playerAnimator.SetTrigger("Insufflation");
    }

    public void LaunchShieldAnimation()
    {
        playerAnimator.SetTrigger("Shield");
    }


}
