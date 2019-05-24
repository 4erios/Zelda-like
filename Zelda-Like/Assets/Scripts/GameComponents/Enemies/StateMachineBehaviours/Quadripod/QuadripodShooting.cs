using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadripodShooting : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //animator.GetComponent<QuadripodClass>().SetQuadripodShootDirection();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //animator.GetComponent<QuadripodClass>().QuadripodShoot();
    }
}
