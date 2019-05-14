using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingClass : MonoBehaviour
{
    public float health;

    public virtual void TakeDamages(float damages)
    {
        health = health - damages;
        if (health <= 0)
        {
            health = 0;
        }
        Debug.Log("Damages Taken");
    }

    public void GainEnergy(FloatVariable currentEnergyTank, FloatReference energyGain, FloatReference maxEnergyTank, IntVariable energyGauge, IntReferences energyMax)
    {
        currentEnergyTank.ApplyChangeToFloat(energyGain);
        if (currentEnergyTank >= maxEnergyTank)
        {
            energyGauge.ApplyChangeToInt(+1);
            currentEnergyTank.SetFloatValue(0);

            if (energyGauge > energyMax)
            {
                energyGauge.SetIntValue(energyMax);
            }
        }

        if (energyGauge == energyMax)
        {
            currentEnergyTank.SetFloatValue(0);
        }
    }

    public virtual void Death()
    {
        Debug.Log("Dead");
        Destroy(this.gameObject);
    }
}
