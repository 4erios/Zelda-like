using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : StateMachineBehaviour
{
    public GameEvent playerAttackSwitch;
    public GameEvent launchTimeToAttack;
    public GameEvent resetAttackTrigger;

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        launchTimeToAttack.Raise();
        resetAttackTrigger.Raise();
    }
}
