using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colosse_Bras : MonoBehaviour
{
    //Reste à faire :
    // - Annimation
    // - Lier fonction "MoveHand()" à l'annimation
    // - Lier l'annimation au script
    // - Mettre les positions en fonction de l'annimation
    // - Mettre les dégâts quand main tombe

    public bool Insufl = false;
    public bool Attack = false;

    private GameObject player;
    private bool playerOn = false; //Si le joueur doit être transporté
    private bool playerMov = false; // Le joueur est transporté
    private bool enMouv = false;

    public Transform colliderHaut; //En haut de la falaise
    public Transform colliderBas; //En bas de la falaise
    public float checkRadius = 0.2f;
    public LayerMask playerMask;

    public bool trapeOnly = false;
    private int actualframe;
    public GameObject[] playerPosition;
    public bool position; //false = bas || true = haut

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Si position de base = true alors mettrz anim main en haut de base
    }

    void Update()
    {
        if (actualframe == 0)
        {
            position = false;
            enMouv = false;
        }
        else if (actualframe == 4)
        {
            position = true;
            enMouv = false;
        }
        else
            enMouv = true;

        #region Player insufle
        if (!position && Insufl)
        {
            if (playerOn)
            {
                playerMov = true;
                player.transform.position = playerPosition[actualframe].transform.position;
            }
            // Lancer anim monter
        }
        #endregion

        #region player attaque
        if (position && Attack)
        {
            if (playerOn)
            {
                playerMov = true;
                player.transform.position = playerPosition[actualframe].transform.position;
            }
            // Lancer anim déscendre
            // Faire dégâts
        }
        #endregion

        if(!trapeOnly)
            playerOn = Physics2D.OverlapCircle(colliderHaut.position, checkRadius, playerMask);

        else if (!playerOn && !trapeOnly)
            playerOn = Physics2D.OverlapCircle(colliderBas.position, checkRadius, playerMask);

    }

    public void Movehand()
    {
        if (!position && playerMov)
        {
            player.transform.position = playerPosition[actualframe].transform.position;
            actualframe++;
            if (actualframe == 4)
                StopPlayer();
        }

        if (position && playerMov)
        {
            player.transform.position = playerPosition[actualframe].transform.position;
            actualframe--;
            if (actualframe == 0)
                StopPlayer();
        }
    }

    private void StopPlayer()
    {
        playerMov = false;

        if (actualframe == 0)
            player.transform.position = colliderBas.position;

        else if (actualframe == 4)
            player.transform.position = colliderHaut.position;
    }
}
