using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHPSystem : MonoBehaviour
{
    public FloatReference playerMaxHP;

    public FloatVariable CurrentHP;

    public bool ResetHP;

    public GameEvent DamageEvent;
    public GameEvent ResurrectionEvent;
    public GameEvent DeathEvent;

    public FloatVariable PlayerDamagesTaken;

    public IntVariable EnergyGauge;

    private void Awake()
    {
        if (ResetHP)
            CurrentHP.SetFloatValue(playerMaxHP);
    }

    public void TakeDamages(float damages)
    {
        CurrentHP.ApplyChangeToFloat(-damages * PlayerDamagesTaken);
        DamageEvent.Raise();
        
        if (CurrentHP.Value <= 0)
        {
            CurrentHP.SetFloatValue(0);
            if (EnergyGauge > 3)
            {
                ResurrectionEvent.Raise();
                Debug.Log("Resurrection");
            }
            else if (EnergyGauge <= 3)
            {
                DeathEvent.Raise();
                Debug.Log("Death");
            }
        }
    }

    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyDamageDealer damages = collision.gameObject.GetComponent<EnemyDamageDealer>();
        if (damages != null)
        {
            CurrentHP.ApplyChangeToFloat(-damages.enemyDamage * PlayerDamagesTaken);
            DamageEvent.Raise();
        }

        if (CurrentHP.Value <= 0)
        {
            CurrentHP.SetFloatValue(0);
            ResurrectionEvent.Raise();
        }
    }*/
}

