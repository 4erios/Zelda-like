using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : InfusableClass
{
    public float damageRange = 1F;
    public bool bigRoots = false;
    private Animator anim;
    [SerializeField]
    private float bigRootsLife = 3;

    public FloatReference damageRoots;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();

        health = bigRootsLife;
        doesItGiveEnergy = true;

        if (bigRoots)
        {
            anim.SetTrigger("Begin Big");
            bigRoots = true;
        }
    }

    void Update()
    {
        #region Big
        if (health <= 0)
        {
            anim.SetBool("Is Attak", true);
            health = bigRootsLife;
        }
        #endregion

        if (takeDamages && bigRoots)
        {
            anim.SetTrigger("Damage");
            takeDamages = false;
            isInfused = false;
        }

        #region Small
        if (!bigRoots && isInfused)
        {
            takeDamages = false;
            anim.SetBool("Is Infused",true);
            FunctionToDealDamages();
            anim.SetBool("Is Infused", false);
        }
        #endregion

        if (bigRoots)
        {
            anim.SetBool("Is Infused", false);
        }

        else if (!bigRoots)
        {
            anim.SetBool("Is Attak", false);
        }
    }

    public void ChangeState()
        {
        bigRoots = !bigRoots;
        }

    private void Heal()
    {
        health = bigRootsLife;
    }

    void FunctionToDealDamages()
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(this.gameObject.transform.position, damageRange);
        foreach (Collider2D enemyCollision in enemiesHurt)
        {
            enemyCollision.GetComponent<LivingClass>().TakeDamages(damageRoots);
        }
    }
}
