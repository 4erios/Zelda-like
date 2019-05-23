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

    private void Update()
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
    
    public void ResurrectionTimer()
    {
        TimeUntilDeath.ApplyChangeToFloat(Time.deltaTime);

        if (TimeUntilDeath >= SetTimeUntilDeath)
        {
            DeathEvent.Raise();
        }
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
        Resurrecting.SetBoolValue(false);
    }

}
