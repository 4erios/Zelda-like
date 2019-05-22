using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stèle : MonoBehaviour
{
    public bool Attack = false;

    private GameObject player;
    [SerializeField]
    private int scoreWin;
    public bool Energy;

    public IntVariable current;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Attack)
        {
            if (Energy)
            {
                //current += scoreWin;
                //Start annim
            }

            else
            {
                //current += scoreWin;
                //Start Annim
            }
        }

    }
}
