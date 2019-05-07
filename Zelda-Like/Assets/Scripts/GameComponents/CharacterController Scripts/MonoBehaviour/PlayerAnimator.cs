using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    public FloatVariable moveX;
    public FloatVariable moveY;


    void Update()
    {
        playerAnimator.SetFloat("MoveX", moveX);
        playerAnimator.SetFloat("MoveY", moveY); 
    }

    public void LaunchAttackAnimation()
    {

    }

    public void LaunchDashAnimation()
    {

    }

    public void LaunchHealAnimation()
    {

    }

    public void LaunchTakeDamageAnimation()
    {

    }

    public void LaunchResurrectionAnimation()
    {

    }

    public void LaunchDeathAnimation()
    {

    }

    public void LaunchShootAnimation()
    {

    }

    public void LaunchInsufflationAnimation()
    {

    }

    public void LaunchShieldAnimation()
    {

    }


}
