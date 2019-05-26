using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{


    public float speed = 20f;
    public Rigidbody2D rb;
    public float lifeTime = 1f; 

    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Destroy(this.gameObject, lifeTime);

        
    


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ennemi"))
        {

            other.GetComponent<LivingClass>().TakeDamages(1);
            other.GetComponent<InfusableClass>().Infuse();
            

        }

    }




    }



