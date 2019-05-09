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
        playerAnimator.SetTrigger("");
    }

    public void LaunchHealAnimation()
    {
        playerAnimator.SetTrigger("");
    }

    public void LaunchTakeDamageAnimation()
    {
        playerAnimator.SetTrigger("");
    }

    public void LaunchResurrectionAnimation()
    {
        playerAnimator.SetTrigger("");
    }

    public void LaunchDeathAnimation()
    {
        playerAnimator.SetTrigger("");
    }

    public void LaunchShootAnimation()
    {
        playerAnimator.SetTrigger("");
    }

    public void LaunchInsufflationAnimation()
    {
        playerAnimator.SetTrigger("");
    }

    public void LaunchShieldAnimation()
    {
        playerAnimator.SetTrigger("");
    }


}
