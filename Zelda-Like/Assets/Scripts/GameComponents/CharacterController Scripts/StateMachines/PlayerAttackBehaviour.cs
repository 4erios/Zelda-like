using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : StateMachineBehaviour
{
    public GameEvent playerAttackSwitch;
    public GameEvent launchTimeToAttack;

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        playerAttackSwitch.Raise();
        launchTimeToAttack.Raise();
    }
}
