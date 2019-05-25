using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadripodProjectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float lifeTime = 20f;

    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame


    /* private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Player"))
         {




         }
     }*/
}
