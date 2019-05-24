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
            anim.SetTrigger("Is Attak");
            health = bigRootsLife;
        }
        #endregion

        #region Small
        if (!bigRoots && isInfused)
        {
            anim.SetBool("Is Infused",true);
            FunctionToDealDamages();
            health = bigRootsLife;
            anim.SetBool("Is Infused", false);
        }
        #endregion

        anim.SetBool("Is Infused", isInfused);
    }

    public void ChangeState()
        {
            bigRoots = !bigRoots;
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
