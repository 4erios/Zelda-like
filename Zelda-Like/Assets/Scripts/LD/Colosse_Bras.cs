﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colosse_Bras : MonoBehaviour
{
    //Reste à faire :
    // Ok! Annimation
    // - Lier fonction "MoveHand()" à l'annimation
    // - Lier l'annimation au script
    // - Mettre les positions en fonction de l'annimation
    // - Mettre les dégâts quand main tombe

    public bool insufl = false;
    public bool attack = false;
    private Animator anim;

    private GameObject player;
    [SerializeField]
    private bool playerOn = false; //Si le joueur doit être transporté
    private bool playerMov = false; // Le joueur est transporté

    public Transform positionHaut;
    public Transform positionBas;
    public float speed = 5;
    public float checkRadius = 2F;
    public LayerMask playerMask;

    public bool trapeOnly = false;
    private int actualframe;
    public bool enHauteur; //false = bas || true = haut

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (!enHauteur && insufl)
        {
            if (playerOn)
            {
                playerMov = true;
            }

            Monter();
        }
        #endregion

        #region player attaque
        if (enHauteur && attack)
        {
            if (playerOn)
            {
                playerMov = true;
            }

            Baisser();
            // Faire dégâts
        }
        #endregion

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

    void Monter()
    {
        if (playerMov && !trapeOnly)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, positionHaut.position, speed * Time.deltaTime);
        }

        anim.SetBool("Is Go Up", true);
    }

    void Baisser()
    {
        if (playerMov && !trapeOnly)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, positionBas.position, speed * 2 * Time.deltaTime);
        }

        anim.SetBool("Is Fall", true);
    }
}
