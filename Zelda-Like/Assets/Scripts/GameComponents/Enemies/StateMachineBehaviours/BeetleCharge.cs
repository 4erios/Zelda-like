using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleCharge : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<BeetleClass>().BeetleCharge();
        animator.GetComponent<BeetleClass>().LaunchDelayBetweenAttacks();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<BeetleClass>().SetBeetleVelocityToZero();
    }
}
