using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : StateMachineBehaviour
{
    public Animator playerAnimator;

    public FloatReference timetoattack;
    public FloatReference timebetweenattacks;

    public IntVariable attacknumber;

    public GameEvent playerCantAttack;
    public GameEvent playerAttackIsFalse;
    public GameEvent playerCanAttackAgain;


    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        PlayerAttackSwitch();
        TimeToAttack();
    }


    public IEnumerator TimeToAttack()
    {
        yield return new WaitForSeconds(timetoattack);
        attacknumber.SetIntValue(0);
        playerCantAttack.Raise();
    }

    public IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(timebetweenattacks);
        playerCanAttackAgain.Raise();
    }

    public void PlayerAttackSwitch()
    {
        switch (attacknumber)
        {
            case 1:
                attacknumber.ApplyChangeToInt(attacknumber + 1);
                break;

            case 2:
                attacknumber.ApplyChangeToInt(attacknumber + 1);
                break;

            case 3:
                attacknumber.SetIntValue(0);
                break;

            case 0:
                attacknumber.ApplyChangeToInt(attacknumber + 1);
                    break;
        }
    }

}
