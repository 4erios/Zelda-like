using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stèle : MonoBehaviour
{
    //Reste à faire :
    // - Annimation
    // - Lier donner le score

    public bool attack = false;

    private GameObject player;
    [SerializeField]
    private int scoreWin;
    public bool Energy = false;

    public IntVariable current;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Energy)
            scoreWin = 8;
    }

    void Update()
    {
        if (attack)
        {
            if (Energy)
            {
                //current += scoreWin;
                //Start annim
            }

            else
            {
                //current += scoreWin;
            }

            //Start Annim
        }

    }
}
