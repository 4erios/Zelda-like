using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingClass : MonoBehaviour
{
    public float health;

    public virtual void TakeDamages(float damages)
    {
        health = health - damages;
        Debug.Log("Damages Taken");
    }

    public virtual void Death()
    {
        Debug.Log("Dead");
        Destroy(this.gameObject);
    }
}
