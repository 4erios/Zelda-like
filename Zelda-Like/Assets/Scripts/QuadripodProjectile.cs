using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadripodProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float lifeTime = 20f;
    public float QuadripodDamage = 10f;


    private void Update()
    {
        Destroy(this.gameObject, lifeTime);
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<PlayerHPSystem>()) return;
        collision.gameObject.GetComponent<PlayerHPSystem>().TakeDamages(QuadripodDamage);
    }
}
