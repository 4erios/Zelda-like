using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterController;
using CharacterController.Variables;

namespace CharacterController.Variables
{
    public class PlayerHPSystem : LivingClass
    {
        public FloatReference playerMaxHP;

        public FloatVariable CurrentHP;

        public bool ResetHP;

        public UnityEvent DamageEvent;

        private void Start()
        {
            if (ResetHP)
                CurrentHP.SetValue(playerMaxHP);
        }

        public override void TakeDamages(float damages)
        {

        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            EnemyDamageDealer damages = collision.gameObject.GetComponent<EnemyDamageDealer>();
            if (damages != null)
            {
                CurrentHP.ApplyChange(-damages.enemyDamage);
                DamageEvent.Invoke(); 
            }
        }
    }
}
