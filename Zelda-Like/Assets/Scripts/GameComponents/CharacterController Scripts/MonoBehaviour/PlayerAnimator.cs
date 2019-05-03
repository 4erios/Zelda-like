using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    public FloatVariable moveX;
    public FloatVariable moveY;

    public bool cantattack = false;

    void Update()
    {
        playerAnimator.SetFloat("MoveX", moveX);
        playerAnimator.SetFloat("MoveY", moveY);
    }

    public void LaunchPlayerAttack()
    {
        if(cantattack == false)
        playerAnimator.SetBool("Attack", true);
    }

    public void PlayerAttackIsFalse()
    {
        playerAnimator.SetBool("Attack", false);
    }

    public void PlayerCantAttack()
    {
        cantattack = true;
        PlayerAttackIsFalse();
    }
}
