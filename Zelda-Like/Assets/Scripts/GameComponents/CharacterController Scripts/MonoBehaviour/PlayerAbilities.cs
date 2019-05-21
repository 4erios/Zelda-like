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

    public Rigidbody2D rb;
    public Transform PlayerTransform;
    public Transform FirePoint;


    [Header("Abilities Parameters")]
    public FloatVariable MoveX;
    public FloatVariable MoveY;

    public FloatReference DashRange;

    public FloatReference HealValue;

    public FloatReference AOEInfuseRange;
    public FloatReference AOEInfuseDamages;

    public FloatVariable PlayerDamagesTaken;
    public FloatReference ShieldDamageTaken;

    //shoot parameters
    private Vector2 FireDirection;
    

    private void LoseEnergy(int energyCost)
    {
        EnergyGauge.ApplyChangeToInt(-energyCost);
        if ( EnergyGauge < 0)
        {
            EnergyGauge.SetIntValue(0);
        }
    }

    public void DashEnergyLoss()
    {
        LoseEnergy(DashEnergyCost);
    }

    public void PlayerDash()
    {
        Vector2 direction = new Vector2(MoveX, MoveY).normalized;
        rb.velocity = new Vector2(direction.x * DashRange, direction.y * DashRange);
    }

    public void HealEnergyLoss()
    {
        LoseEnergy(HealEnergyCost);
    }

    public void PlayerHeal()
    {
        CurrentHP.ApplyChangeToFloat(HealValue);
        if (CurrentHP >= MaxHP)
        {
            CurrentHP.SetFloatValue(MaxHP);
        }
    }

    public void AOEInfuseEnergyLoss()
    {
        LoseEnergy(AOEInfuseCost);

    }

    public void PlayerAOEInfuse()
    {
        /*Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(DownAttackPoint.position, AttackRange);
        foreach (Collider2D enemyCollision in enemiesHurt) //(int i = 0; i < enemiesHurt.Length; i++)
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);

        }*/

        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(PlayerTransform.position, AOEInfuseRange);
        for (int i = 0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(AOEInfuseDamages);
            //enemiesHurt[i].GetComponent<LivingClass>().Knockback();
            //enemiesHurt[i].GetComponent<InfusableComponentClass>().Infuse();
            Debug.Log("AOE touchée");
            Debug.Log(i);
        }
    }

    public void ShootEnergyLoss()
    {
        LoseEnergy(ShootInfuseCost);
    }

    public void PlayerShootInfuse()
    {
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, Vector2.right);
        if (hit.collider != null)
        {
            FireDirection = new Vector2(hit.point.x - FirePoint.position.x, hit.point.y - FirePoint.position.y);
        }
    }

    public void ShieldEnergyLoss()
    {
        LoseEnergy(ShieldCost);
    }

    public void PlayerShield()
    {
        PlayerDamagesTaken.SetFloatValue(ShieldDamageTaken);
    }

    public void StopPlayerShield()
    {
        PlayerDamagesTaken.SetFloatValue(1);
    }

}
