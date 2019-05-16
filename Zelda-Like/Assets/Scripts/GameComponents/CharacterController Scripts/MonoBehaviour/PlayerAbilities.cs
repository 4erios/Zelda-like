using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [Header("Energy Variables")]
    public IntVariable EnergyGauge;
    public IntReferences EnergyMax;

    [Header("Abilities Energy Cost")]
    public IntReferences DashEnergyCost;
    public IntReferences HealEnergyCost;
    public IntReferences AOEInfuseCost;
    public IntReferences ShootInfuseCost;
    public IntReferences ShieldCost;

    [Header("Refered Components")]
    public FloatVariable CurrentHP;
    public FloatReference MaxHP;

    [Header("Abilities Parameters")]
    public Rigidbody2D rb;

    public FloatVariable MoveX;
    public FloatVariable MoveY;

    public FloatReference DashRange;

    public FloatReference HealValue;
    

    private void LoseEnergy(int energyCost)
    {
        EnergyGauge.ApplyChangeToInt(-energyCost);
        if ( EnergyGauge < 0)
        {
            EnergyGauge.SetIntValue(0);
        }
    }

    public void PlayerDash()
    {
        LoseEnergy(DashEnergyCost);

        Vector2 direction = new Vector2(MoveX, MoveY);
        rb.AddForce(direction * DashRange);
    }

    public void PlayerHeal()
    {
        CurrentHP.ApplyChangeToFloat(HealValue);
        LoseEnergy(HealEnergyCost);
        if (CurrentHP >= MaxHP)
        {
            CurrentHP.SetFloatValue(MaxHP);
        }
    }

    public void PlayerAOEInfuse()
    {
        LoseEnergy(AOEInfuseCost);
    }

    public void PlayerShootInfuse()
    {
        LoseEnergy(ShootInfuseCost);
    }

    public void PlayerShield()
    {
        LoseEnergy(ShieldCost);
    }
}
