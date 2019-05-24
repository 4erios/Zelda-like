using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colosse_Bras : InfusableClass
{
    //Reste à faire :
    // - Mettre les dégâts quand main tombe

    private Animator anim;
    public Collider2D poignetCollider;
    public Collider2D doigtsCollider;
    public bool trapeOnly = false;
    public float damageRange = 2F;
    public Transform underHandRange;

    public FloatReference damageHand;

    public float fallTime = 5f;
    private int actualframe;
    public bool enHauteur; //false = bas || true = haut

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        #region Up on load
        if (enHauteur)
        {
            anim.SetTrigger("Up On Load");
            actualframe = 5;
        }
        #endregion
    }

    void Update()
    {
        if (actualframe == 0)
        {
            enHauteur = false;
            anim.SetBool("Is Fall", false);
        }

        else if (actualframe == 5)
        {
            enHauteur = true;
            anim.SetBool("Is Go Up", false);
        }

        #region Player insufle
        if (!enHauteur && isInfused)
        {
            anim.SetBool("Is Go Up", true);
            StartCoroutine(TimeBeforeFall());
            isInfused = false;
        }
        #endregion

        #region player attaque
        if (enHauteur && health <= 0)
        {
            anim.SetBool("Is Fall", true);
            FunctionToDealDamages();
        }
        #endregion

        if (trapeOnly && !enHauteur)
        {
            poignetCollider.isTrigger = false;
            doigtsCollider.isTrigger = false;
        }

        Debug.Log(actualframe);
    }

    public void Movehand()
    {
        if (!enHauteur)
        {
            actualframe++;

            if (actualframe == 5)
                health = 1;
        }

        if (enHauteur)
        {
            if (actualframe == 9)
                    actualframe = 0;
            else
                actualframe++;
        }
    }

    IEnumerator TimeBeforeFall()
    {
        yield return new WaitForSeconds(fallTime);

        if (enHauteur)
        {
            health = 0;
        }
    }

    void FunctionToDealDamages()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(underHandRange.position, damageRange);
        foreach (Collider2D enemyCollision in enemiesHurt)
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(damageHand);
        }
    }
}
