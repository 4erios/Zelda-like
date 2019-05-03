using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackFunctions : MonoBehaviour
{
    public Animator playerAnimator;

    public FloatReference timetoattack;
    public FloatReference timebetweenattacks;

    public IntVariable attacknumber;

    public GameEvent playerCantAttack;
    public GameEvent playerAttackIsFalse;
    public GameEvent playerCanAttackAgain;

    private int i;

    private void Start()
    {
        //attacknumber.SetIntValue(0);
    }

    private void Update()
    {
        playerAnimator.SetInteger("ComboCounter",i);
        if (Input.GetButtonDown("ButtonA"))
        {
            playerAnimator.SetTrigger("AttackButton");
            Debug.Log(i);
            //playerAnimator.SetInteger("ComboCounter", +1);
            
       
            playerAnimator.SetInteger("ComboCounter", i++);
            if (i>=3)
            {

                i = 0;
            }
        }

    }

    /*public IEnumerator TimeToAttack()
    {
        yield return new WaitForSeconds(timetoattack);
        attacknumber.SetIntValue(0);
        playerCantAttack.Raise();
        StartCoroutine("AttackCoolDown");
    }

    public IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(timebetweenattacks);
        playerCanAttackAgain.Raise();
    }

    public void LaunchTimeToAttack()
    {
        StartCoroutine("TimeToAttack");
    }

    public void PlayerAttackSwitch()
    {
        switch (attacknumber)
        {
            case 0:
                attacknumber.SetIntValue(1);
                break;

            case 1:
                attacknumber.SetIntValue(2);
                break;

            case 2:
                attacknumber.SetIntValue(0);
                break;
    

        }
    }*/
}
