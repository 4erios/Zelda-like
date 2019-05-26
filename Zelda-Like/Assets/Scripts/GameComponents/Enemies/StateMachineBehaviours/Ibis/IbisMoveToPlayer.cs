using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbisMoveToPlayer : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().DelayBetweenBeetlesSpawn();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().IbisMoveToPlayer();
        animator.GetComponent<IbisClass>().IbisEnterAttackRange();
        animator.GetComponent<IbisClass>().IbisEnterMeleeAttackRange();
    }
}
