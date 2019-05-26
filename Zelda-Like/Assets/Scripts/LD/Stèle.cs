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
    private float scoreWin = 80f;
    public bool Energy = false;

    public FloatVariable soulsGiven;

    void Start()
    {
        doesItGiveEnergy = true;
        player = GameObject.FindGameObjectWithTag("Player");
        if (Energy)
            scoreWin = 80f;
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {

            anim.SetTrigger("Destroy");
            if (Energy)
            {
                //current += scoreWin;
            }

            else
            {
                player.GetComponent<PlayerSouls>().TakeSouls(soulsGiven);
            }

           
        }

        if (takeDamages)
        {
            anim.SetTrigger("Damage");
            takeDamages = false;
        }

    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
