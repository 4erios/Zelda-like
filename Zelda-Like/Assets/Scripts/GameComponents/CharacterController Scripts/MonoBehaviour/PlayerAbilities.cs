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

    public FloatVariable PlayerDamagesTaken;
    public FloatReference ShieldDamageTaken;

    public Rigidbody2D shootPrefab;
   // public List<Pool> pools;
    //public Dictionary<string, Queue<GameObject>> poolDictionary;
    public Transform shootingPoint;
    public FloatReference prefabSpeed;

    //shoot parameters
    private Vector2 FireDirection;
   // PlayerAbilities playerAbilities;

   // [System.Serializable]
    /*public class Pool
    {

        public string tag;
        public GameObject prefab;
        public int size; 



    }

    #region Singleton 

    public static PlayerAbilities Instance;

    private void Awake()
    {

        Instance = this;
    }


    #endregion 

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {


            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {


                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);


            }

            poolDictionary.Add(pool.tag, objectPool);

        }

        playerAbilities = PlayerAbilities.Instance;
    }

    private void FixedUpdate()
    {
        PlayerAbilities.Instance.SpawnFromPool("Infuse", transform.position, Quaternion.identity);
    }

    public GameObject SpawnFromPool (string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {

            Debug.Log("Warning");
                return null;


        }

       GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }*/

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
        DashEnergyLoss();
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
        HealEnergyLoss();
    }

    public void AOEInfuseEnergyLoss()
    {
        LoseEnergy(AOEInfuseCost);

    }

    public void PlayerAOEInfuse()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(AOEEmissionPoint.position, AOEInfuseRange);
        foreach (Collider2D enemyCollision in enemiesHurt) 
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(AOEInfuseDamages);
            enemyCollision.GetComponent<EnemyClass>().KnockBack(AOEInfuseKnockBackDistance);
            enemyCollision.GetComponent<InfusableClass>().Infuse();

        }

        PlayerAOEInfuse();

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
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, Vector2.right);
        if (hit.collider != null)
        {
            FireDirection = new Vector2(hit.point.x - FirePoint.position.x, hit.point.y - FirePoint.position.y);
            hit.collider.GetComponent<InfusableClass>().Infuse();
        }

        Rigidbody2D clone;

        clone = Instantiate(shootPrefab, shootingPoint.position, shootingPoint.rotation);
        clone.velocity = FireDirection * prefabSpeed;
        Debug.Log("Instantiate PrefabSpawn");
        ShootEnergyLoss();
    }

    public void ShieldEnergyLoss()
    {
        LoseEnergy(ShieldCost);
    }

    public void PlayerShield()
    {
        PlayerDamagesTaken.SetFloatValue(ShieldDamageTaken);
        ShieldEnergyLoss();
    }

    public void StopPlayerShield()
    {
        PlayerDamagesTaken.SetFloatValue(1);
    }

}
