using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbisMeleeAttack : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().StopDelayBetweenAttacks();
        animator.GetComponent<IbisClass>().SetIbisVelocityToZero();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().DelayBetweenAttacks();
    }
}
