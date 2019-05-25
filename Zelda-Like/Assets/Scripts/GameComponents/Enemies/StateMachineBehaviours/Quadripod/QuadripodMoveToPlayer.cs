using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadripodMoveToPlayer : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<QuadripodClass>().QuadripodMoveToPlayer();
        animator.GetComponent<QuadripodClass>().QuadripodEnterAttackRange();
    }
}
