using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colosse_Bras_Prototype : MonoBehaviour
{
    //Reste à faire :
    // Ok! Annimation
    // - Lier fonction "MoveHand()" à l'annimation
    // - Lier l'annimation au script
    // - Mettre les positions en fonction de l'annimation
    // - Mettre les dégâts quand main tombe
    // - Mettre délais retombe 3s

    public bool insufl = false;
    public bool attack = false;
    private Animator anim;

    private GameObject player;
    [SerializeField]
    private bool playerOn = false; //Si le joueur doit être transporté
    private bool playerMov = false; // Le joueur est transporté

    public Transform colliderHaut; //En haut de la falaise
    public Transform colliderBas; //En bas de la falaise
    public float checkRadius = 0.2f;
    public LayerMask playerMask;

    public bool trapeOnly = false;
    [SerializeField]
    private int actualframe;
    public GameObject[] playerPosition;
    public bool positionHaut; //false = bas || true = haut

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        #region Up on load
        if (positionHaut)
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
            positionHaut = false;
            anim.SetBool("Is Fall", false);
        }
        else if (actualframe == 5)
        {
            positionHaut = true;
            anim.SetBool("Is Go Up", false);
        }

        #region Player insufle
        if (!positionHaut && insufl)
        {
            anim.SetBool("Is Go Up", true);

            if (playerOn)
            {
                playerMov = true;
            }
        }
        #endregion

        #region player attaque
        if (positionHaut && attack)
        {
            if (playerOn)
            {
                playerMov = true;
                //player.transform.position = playerPosition[actualframe].transform.position;
            }
            anim.SetBool("Is Fall", true);
            // Faire dégâts
        }
        #endregion

        if(!playerOn && !trapeOnly && positionHaut)
            playerOn = Physics2D.OverlapCircle(colliderHaut.position, checkRadius, playerMask);

        else if (!playerOn && !trapeOnly && !positionHaut)
            playerOn = Physics2D.OverlapCircle(colliderBas.position, checkRadius, playerMask);

    }

    public void Movehand()
    {
        if (!positionHaut)
        {
            if (playerMov)
                player.transform.position = playerPosition[actualframe].transform.position;

            actualframe++;

            if (actualframe == 5 && playerMov)
                StopPlayer();
        }

        if (positionHaut)
        {
            if (playerMov)
                player.transform.position = playerPosition[actualframe].transform.position;

            if (actualframe == 8)
                    actualframe = 0;
            else
                actualframe++;

            if (actualframe == 0 && playerMov)
                StopPlayer();
        }
    }

    private void StopPlayer()
    {
        playerMov = false;

        if (actualframe == 0)
            player.transform.position = colliderBas.position;

        else if (actualframe == 5)
            player.transform.position = colliderHaut.position;
    }

    public void UpFrame()
    {
        actualframe = 5;
        positionHaut = true;
    } //Résoudre certains Bugs

    public void DownFrame()
    {
        actualframe = 0;
        positionHaut = false;
    } //Résoudre certain Bugs
}
