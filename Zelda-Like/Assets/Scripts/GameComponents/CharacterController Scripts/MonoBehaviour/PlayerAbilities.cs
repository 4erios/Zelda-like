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
    public Transform FirePoint;


    [Header("Abilities Parameters")]
    public FloatVariable MoveX;
    public FloatVariable MoveY;

    public FloatReference DashRange;

    public FloatReference HealValue;

    public FloatReference AOEInfuseRange;
    public FloatReference AOEInfuseKnockBackDistance;
    public FloatReference AOEInfuseDamages;
    public Transform AOEEmissionPoint;
    public LayerMask LayerToAttack;

    public FloatVariable PlayerDamagesTaken;
    public FloatReference ShieldDamageTaken;
    public BoolVariable Shielding;
    public FloatReference ShieldTime;

    // public Rigidbody2D shootPrefab;
    public GameObject shootPrefab;
    public Transform shootingPoint;
    public Transform shootingAxis;
    public FloatReference prefabSpeed;
    private Animator anim;
    public Animator Rez;

    public BoolVariable Healing;

    [Range(-180,180)]
    public int ajout;

    //shoot parameters
    private Vector2 FireDirection;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        
    
    }

    

    private void FixedUpdate()
    {
        if (Healing)
        {
            PlayerHeal(); 
        }
    }

    public void Update()
    {
        Twist();
        anim.SetFloat("PlayerEnergy", EnergyGauge);
    }

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
        if (EnergyGauge >= DashEnergyCost)
        {
            Vector2 direction = new Vector2(MoveX, MoveY).normalized;
            rb.velocity = new Vector2(direction.x * DashRange, direction.y * DashRange);
            DashEnergyLoss();
        }
    }

    public void HealEnergyLoss()
    {
        LoseEnergy(HealEnergyCost);
    }

    public void PlayerHeal()
    {
        if (EnergyGauge >= HealEnergyCost)
        {
            CurrentHP.ApplyChangeToFloat(HealValue);
            if (CurrentHP >= MaxHP)
            {
                CurrentHP.SetFloatValue(MaxHP);

            }
            HealEnergyLoss();
        }
    }

    public void LaunchHeal()
    {
        Healing.SetBoolValue(true);
        Rez.SetBool("OnPressHeal", true);
    }

    public void StopHeal()
    {
        Healing.SetBoolValue(false);
        Rez.SetBool("OnPressHeal", false);
    }

    public void AOEInfuseEnergyLoss()
    {
        LoseEnergy(AOEInfuseCost);
    }

    public void PlayerAOEInfuse()
    {
        if (EnergyGauge >= AOEInfuseCost)
        {
            Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(AOEEmissionPoint.position, AOEInfuseRange, LayerToAttack);
            foreach (Collider2D enemyCollision in enemiesHurt)
            {
                enemyCollision.GetComponent<LivingClass>().TakeDamages(AOEInfuseDamages);
                enemyCollision.GetComponent<InfusableClass>().Infuse();

            }
        }

        /*Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(PlayerTransform.position, AOEInfuseRange);
        for (int i = 0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(AOEInfuseDamages);
            //enemiesHurt[i].GetComponent<LivingClass>().Knockback();
            //enemiesHurt[i].GetComponent<InfusableComponentClass>().Infuse();
            Debug.Log("AOE touchée");
            Debug.Log(i);
        }*/
    }

    public void ShootEnergyLoss()
    {
        LoseEnergy(ShootInfuseCost);
    }

    public void PlayerShootInfuse()
     {
         if(EnergyGauge >= ShootInfuseCost)
         {

            Instantiate(shootPrefab, FirePoint.position, FirePoint.rotation);

            /* RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, Vector2.right);
             if (hit.collider != null)
             {
                 FireDirection = new Vector2(hit.point.x - FirePoint.position.x, hit.point.y - FirePoint.position.y);
                 hit.collider.GetComponent<InfusableClass>().Infuse();
             }
             Rigidbody2D clone;

             clone = Instantiate(shootPrefab, shootingPoint.position, shootingPoint.rotation);
             clone.velocity = FireDirection * prefabSpeed;
             Debug.Log("Instantiate PrefabSpawn");*/





             ShootEnergyLoss();
         }
     }

    void Twist()
    {
        float h1 = Input.GetAxis("Horizontal");
        float v1 = Input.GetAxis("Vertical");

        //Debug.Log("y = " + v1 + " et x = " + h1);

        //Debug.Log("y = " + v1 + " et x = " + h1);

        if (h1 > 0.62f || h1 < -0.62f || v1 > 0.62f || v1 < -0.62f)
        {
            shootingAxis.transform.localEulerAngles = new Vector3(0f, 0f, -(Mathf.Atan2(h1, v1) * 180 / Mathf.PI) + ajout); // this does the actual rotaion according to inputs
        }


    }

   /* public void UseWave()
    {
        Vector2 rotationVector = new Vector2(target.position.x - myShooterTransform.position.x, target.position.y - myShooterTransform.position.y);
        float angleValue = Mathf.Atan2(rotationVector.normalized.y, rotationVector.normalized.x) * Mathf.Rad2Deg;

        ParticleSystem.ShapeModule wpshape = myShooter.shape;
        wpshape.rotation = new Vector3(0, 0, angleValue);

        myShooter.Emit(1);
    }


    private void RotationUpdater()
    {
        waveManager.WaveShooters[waveManager.selectionIndex].startRotation = -targetRotator.localRotation.ToEulerAngles().z;
    }*/


    public void ShieldEnergyLoss()
    {
        LoseEnergy(ShieldCost);
    }

    public void PlayerShield()
    {
        if (EnergyGauge >= ShieldCost)
        {
            PlayerDamagesTaken.SetFloatValue(ShieldDamageTaken);
            Shielding.SetBoolValue(true);
            StopCoroutine("ShieldTimeCoroutine");
            ShieldEnergyLoss();
        }
    }

    public void StopPlayerShield()
    {
        Shielding.SetBoolValue(false);
        PlayerDamagesTaken.SetFloatValue(1);
        Debug.Log("Stop Shield");
    }

    public IEnumerator ShieldTimeCoroutine()
    {
        yield return new WaitForSeconds(ShieldTime);
        StopPlayerShield();
    }

    public void StartShieldCoroutine()
    {
        Debug.Log("Start Shield Coroutine");
        StartCoroutine("ShieldTimeCoroutine");
    }

}
