// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyDamageDealer : MonoBehaviour
{
    public FloatReference enemyDamage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.GetComponent<PlayerHPSystem>()) return;
        collision.gameObject.GetComponent<PlayerHPSystem>().TakeDamages(enemyDamage);
    }
}


