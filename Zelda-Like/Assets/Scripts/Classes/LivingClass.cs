using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingClass : MonoBehaviour
{
    public float health;

    public virtual void TakeDamages(float damages)
    {
        health = health - damages;
        if (health <= 0)
        {
            health = 0;
        }
        Debug.Log("Damages Taken");
    }

    public virtual void Death()
    {
        Debug.Log("Dead");
        Destroy(this.gameObject);
    }
}
