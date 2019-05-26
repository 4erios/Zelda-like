using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbisRangeAttack : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().SetIbisVelocityToZero();
        animator.GetComponent<IbisClass>().StopDelayBetweenAttacks();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().DelayBetweenAttacks();
        animator.GetComponent<IbisClass>().ShootAcidSpray();
    }
}
