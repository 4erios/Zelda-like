using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadripodShooting : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<QuadripodClass>().SetQuadripodVelocityToZero();
        animator.GetComponent<QuadripodClass>().StopDelayBetweenAttacks();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<QuadripodClass>().QuadripodShoot();
        animator.GetComponent<QuadripodClass>().LaunchDelayBetweenAttacks();
    }
}
