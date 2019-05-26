using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    public FloatReference PlayerAttackDamages;
    public FloatReference AttackRange;
    public FloatReference AttackKnockBackDistance;

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

    [Header("AttackInertiaComponents")]
    public Rigidbody2D rb;
    public FloatVariable MoveX;
    public FloatVariable MoveY;

    public FloatReference FirstDashRange;
    public FloatReference SecondDashRange;
    public FloatReference ThirdDashRange;

    private void Start()
    {
        //AttackCount.SetIntValue(0);
    }

    private void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            AttackInertia();
        }
    }

    public void RightAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(RightAttackPoint.position, AttackRange, layerToAttack);
        foreach (Collider2D enemyCollision in enemiesHurt) 
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
           // enemyCollision.GetComponent<EnemyClass>().KnockBack(AttackKnockBackDistance);
            enemyCollision.GetComponent<LivingClass>().GainEnergy(CurrentEnergyTank, EnergyGain, MaxEnergyTank, EnergyGauge, EnergyMax);
        }
    }

    public void LeftAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(LeftAttackPoint.position, AttackRange, layerToAttack);
        foreach (Collider2D enemyCollision in enemiesHurt) 
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
            //enemyCollision.GetComponent<EnemyClass>().KnockBack(AttackKnockBackDistance);
            enemyCollision.GetComponent<LivingClass>().GainEnergy(CurrentEnergyTank, EnergyGain, MaxEnergyTank, EnergyGauge, EnergyMax);
        }
    }

    public void UpAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(UpAttackPoint.position, AttackRange, layerToAttack);
        foreach (Collider2D enemyCollision in enemiesHurt) 
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
            //enemyCollision.GetComponent<EnemyClass>().KnockBack(AttackKnockBackDistance);
            enemyCollision.GetComponent<LivingClass>().GainEnergy(CurrentEnergyTank, EnergyGain, MaxEnergyTank, EnergyGauge, EnergyMax);
        }
    }

    public void DownAttackCollider()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(DownAttackPoint.position, AttackRange, layerToAttack);
        foreach (Collider2D enemyCollision in enemiesHurt) 
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(PlayerAttackDamages);
            //enemyCollision.GetComponent<EnemyClass>().KnockBack(AttackKnockBackDistance);
            enemyCollision.GetComponent<LivingClass>().GainEnergy(CurrentEnergyTank, EnergyGain, MaxEnergyTank, EnergyGauge, EnergyMax);
        }
    }

    public IEnumerator TimeToAttackCoroutine()
    {
        Debug.Log(TimeToAttack);
        yield return new WaitForSeconds(TimeToAttack);
        AttackCount.SetIntValue(3);
        LaunchAttackCoolDown();
    }

    public void LaunchTimeToAttack()
    {
        StartCoroutine("TimeToAttackCoroutine");
        //Debug.Log("LaunchTimeToAttack");
    }

    public void StopTimeToAttackCoroutine()
    {
        StopCoroutine("TimeToAttackCoroutine");
        Debug.Log("TimeToAttack Stopped");
    }

    public IEnumerator AttackCoolDownCoroutine()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        AttackCount.SetIntValue(0);
        //Debug.Log("AttackCoolDown");
    }

    public void LaunchAttackCoolDown()
    {
        StartCoroutine("AttackCoolDownCoroutine");
        //Debug.Log("LaunchAttackCoolDown");
    }

    public void StopAttackCoolDownCoroutine()
    {
        StopCoroutine("AttackCoolDownCoroutine");
    }

    public void UpAttackCount()
    {
        if (AttackCount < 3)
        {
            AttackCount.ApplyChangeToInt(+1);
            //Debug.Log("UpAttackCount");
        }
    }

    public void SetDashAttackDirection()
    {
        Vector2 direction = new Vector2(MoveX, MoveY).normalized;
    }

    private void DashAttack(float dashRange)
    {
        Vector2 direction = new Vector2(MoveX, MoveY).normalized;
        rb.velocity = new Vector2(direction.x * dashRange, direction.y * dashRange);
        Debug.Log("DashAttack");
    }

    public void AttackInertia()
    {
        switch (AttackCount)
        {
            case 0:
                DashAttack(FirstDashRange);
                Debug.Log("FirstDash");
                Debug.Log(FirstDashRange);
                break;
            case 1:
                DashAttack(SecondDashRange);
                Debug.Log("SecondDash");
                Debug.Log(SecondDashRange);
                break;
            case 2:
                DashAttack(ThirdDashRange);
                Debug.Log("ThirdDash");
                Debug.Log(ThirdDashRange);
                break;
        }
    }
}
