using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHPSystem : LivingClass
{
    public FloatReference playerMaxHP;

    public FloatVariable CurrentHP;

    public bool ResetHP;

    [SerializeField] private GameEvent DamageEvent;
    [SerializeField] private GameEvent ResurrectionEvent;

    private void Start()
    {
        if (ResetHP)
            CurrentHP.SetValue(playerMaxHP);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyDamageDealer damages = collision.gameObject.GetComponent<EnemyDamageDealer>();
        if (damages != null)
        {
            CurrentHP.ApplyChange(-damages.enemyDamage);
            DamageEvent.Raise();
        }

        if (CurrentHP.Value <= 0)
        {
            CurrentHP.SetValue(0);
            ResurrectionEvent.Raise();
        }
    }
}

