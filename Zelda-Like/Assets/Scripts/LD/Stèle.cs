using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stèle : LivingClass
{
    private GameObject player;
    private Animator anim;
    public bool Energy = false;

    public FloatVariable soulsGiven;
    public FloatVariable currentSouls;
    public IntVariable currentEnergy;

    void Start()
    {
        doesItGiveEnergy = true;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            if (Energy)
            {
                currentEnergy.SetIntValue(80);
            }

            else
            {
                currentSouls.ApplyChangeToFloat(soulsGiven);
                health = 100;
            }

            anim.SetTrigger("Destroy");
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
