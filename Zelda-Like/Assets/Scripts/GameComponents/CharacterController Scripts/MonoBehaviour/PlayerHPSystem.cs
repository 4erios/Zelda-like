﻿using System.Collections;
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

    public FloatVariable PlayerDamagesTaken;

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
            ResurrectionEvent.Raise();
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

