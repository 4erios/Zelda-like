using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResurrectionScript : MonoBehaviour
{
    public FloatVariable CurrentHP;

    public IntVariable CurrentEnergy;

    public FloatReference SetTimeUntilDeath;

    public BoolVariable Healing;

    public FloatVariable TimeUntilDeath;

    public GameEvent DeathEvent;

    public BoolVariable Resurrecting;

    public Animator anim;
    

    private void FixedUpdate()
    {
        if (Resurrecting)
        {
            UpdateTimer();
        }
    }

    public void ResetResurrectionTimer()
    {
        TimeUntilDeath.SetFloatValue(0);
    }
    
    // Permet de tuer avec le timer
    public void ResurrectionTimer()
    {
        /*TimeUntilDeath.ApplyChangeToFloat(1);

        if (TimeUntilDeath >= SetTimeUntilDeath)
        {
            DeathEvent.Raise();
        }*/

        StartCoroutine(BeforeDeath());

    }

    public void UpdateTimer()
    {
        if (!Healing)
        {
            ResurrectionTimer();
        }
    }

    public void IsResurrecting()
    {
        Resurrecting.SetBoolValue(true);
    }

    public void StopResurrecting()
    {
        StopCoroutine(BeforeDeath());

    }

    IEnumerator BeforeDeath()
    {
        
        yield return new WaitForSeconds(TimeUntilDeath);
        anim.SetTrigger("Death");
    }








}
