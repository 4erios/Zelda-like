using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbisSearchOfPlayer : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<IbisClass>().IbisSearchForPlayer();
    }
}
