using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    public FloatVariable moveX;
    public FloatVariable moveY;

    public IntVariable AttackCount;


    void Update()
    {
        playerAnimator.SetFloat("MoveX", moveX);
        playerAnimator.SetFloat("MoveY", moveY);
        playerAnimator.SetInteger("AttackCount", AttackCount);
    }

    public void LaunchAttackAnimation()
    {
        playerAnimator.SetTrigger("");
    }

    public void LaunchDashAnimation()
    {
        playerAnimator.SetTrigger("Dash");
    }

    public void LaunchHealAnimation()
    {
        playerAnimator.SetTrigger("Heal");
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
        playerAnimator.SetTrigger("");
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
