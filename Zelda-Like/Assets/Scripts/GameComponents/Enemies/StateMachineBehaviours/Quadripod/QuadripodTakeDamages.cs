using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadripodTakeDamages : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //animator.GetComponent<QuadripodClass>().SetQuadripodVelocityToZero();
        animator.GetComponent<LivingClass>().SetBooltakeDamagesToFalse();
        animator.GetComponent<QuadripodClass>().SetKnockBackDirection();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<QuadripodClass>().KnockBack();
    }

}
