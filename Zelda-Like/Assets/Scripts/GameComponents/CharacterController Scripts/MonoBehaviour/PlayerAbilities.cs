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

    [Header("Abilities Parameters")]
    public Rigidbody2D rb;

    public FloatVariable MoveX;
    public FloatVariable MoveY;

    public FloatReference DashRange;

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
        rb.MovePosition(rb.position + direction * DashRange);
    }

    public void PlayerHeal()
    {

    }

    public void PlayerAOEInfuse()
    {

    }

    public void PlayerShootInfuse()
    {

    }

    public void PlayerShield()
    {

    }
}
