﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colosse_Bras : MonoBehaviour
{
    //Reste à faire :
    // - Mettre les dégâts quand main tombe

    public bool isInfused = false;
    public bool attack = false;

    private Animator anim;
    public Collider2D poignetCollider;
    public Collider2D doigtsCollider;
    public bool trapeOnly = false;

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
        }
        #endregion

        #region player attaque
        if (enHauteur && attack)
        {
            anim.SetBool("Is Fall", true);
            // Faire dégâts 
        }
        #endregion

        if (trapeOnly && !enHauteur)
        {
            poignetCollider.isTrigger = false;
            doigtsCollider.isTrigger = false;
        }

    }

    public void Movehand()
    {
        if (!enHauteur)
        {
            actualframe++;

        }

        if (enHauteur)
        {
            if (actualframe == 8)
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
            attack = true;
            yield return new WaitForSeconds(0.5F);
            attack = false;
        }
    }
}
