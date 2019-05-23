using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stèle : LivingClass
{
    //Reste à faire :
    // - Lier donner le score

    private GameObject player;
    private Animator anim;
    [SerializeField]
    private int scoreWin;
    public bool Energy = false;

    public IntVariable current;

    void Start()
    {
        doesItGiveEnergy = true;
        player = GameObject.FindGameObjectWithTag("Player");
        if (Energy)
            scoreWin = 8;
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            if (Energy)
            {
                //current += scoreWin;
            }

            else
            {
                //current += scoreWin;
            }

            anim.SetTrigger("Destroy");
        }

    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
