using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbisTakeDamages : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<LivingClass>().SetBooltakeDamagesToFalse();
        animator.GetComponent<IbisClass>().SetKnockBackDirection();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().KnockBack();
    }
}
