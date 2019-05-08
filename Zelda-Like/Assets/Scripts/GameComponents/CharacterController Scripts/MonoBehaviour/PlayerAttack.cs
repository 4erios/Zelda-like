using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    public FloatReference PlayerAttackDamages;
    public FloatReference AttackRange;

    public FloatReference TimeToAttack;
    public FloatReference AttackCoolDown;

    public IntVariable AttackCount;

    public Transform RightAttackPoint;
    public Transform LeftAttackPoint;
    public Transform UpAttackPoint;
    public Transform DownAttackPoint;

    public LayerMask layerToAttack;

    [Header("EnergyGain Parameters")]
    public FloatVariable CurrentEnergyTank;
    public FloatReference EnergyGain;
    public FloatReference MaxEnergyTank;

    public IntVariable EnergyGauge;
    public IntReferences EnergyMax; 

    public void RightAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(RightAttackPoint.position, AttackRange);
        for (int i = 0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
            Debug.Log("Ennemi touché");
            Debug.Log(i);
        }
    }

    public void LeftAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(LeftAttackPoint.position, AttackRange);
        for (int i = 0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
            Debug.Log("Ennemi touché");
            Debug.Log(i);
        }
    }

    public void UpAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(UpAttackPoint.position, AttackRange);
        for (int i = 0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
            Debug.Log("Ennemi touché");
            Debug.Log(i);
        }
    }

    public void DownAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(DownAttackPoint.position, AttackRange);
        for (int i = 0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
            Debug.Log("Ennemi touché");
            Debug.Log(i);
        }
    }

    public IEnumerator TimeToAttackCoroutine()
    {
        yield return new WaitForSeconds(TimeToAttack);
    }

    public void LaunchTimeToAttack()
    {
        StartCoroutine("TimeToAttackCoroutine");
        AttackCount.SetIntValue(3);
    }

    public IEnumerator AttackCoolDownCoroutine()
    {
        yield return new WaitForSeconds(AttackCoolDown);
    }

    public void LaunchAttackCoolDown()
    {
        StartCoroutine("AttackCoolDownCoroutine");
        AttackCount.SetIntValue(0);
    }

    public void UpAttackCount()
    {
        AttackCount.ApplyChangeToInt(+1);
    }

    public void GainEnergy(float energyGain)
    {
        CurrentEnergyTank.ApplyChangeToFloat(EnergyGain);
        if (CurrentEnergyTank >= MaxEnergyTank)
        {
            EnergyGauge.ApplyChangeToInt(+1);
            CurrentEnergyTank.SetFloatValue(0);

            if (EnergyGauge > EnergyMax)
            {
                EnergyGauge.SetIntValue(EnergyMax);
            }
        }

        if (EnergyGauge == EnergyMax)
        {
            CurrentEnergyTank.SetFloatValue(0);
        }
    }
}
