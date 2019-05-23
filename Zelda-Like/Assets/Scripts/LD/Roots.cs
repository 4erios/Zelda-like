using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : InfusableClass
{
    //Reste à faire :
    // - Dégâts ennemis 

    public bool attack = false;

    public float damageRange = 1F;
    public bool bigRoots = false;
    private Animator anim;
    [SerializeField]
    private float bigRootsLife = 3;
    private float countDamage;

    public FloatReference Damage;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();

        if (bigRoots)
        {
            anim.SetTrigger("Begin Big");
            bigRoots = true;
        }
    }

    void Update()
    {
        #region Big
        if (bigRoots && attack)
        {
            countDamage++;
            attack = false;
        }

        if (countDamage == bigRootsLife)
        {
            attack = false;
            anim.SetTrigger("Is Attak");
            countDamage = 0;
        }
        #endregion

        #region Small
        if (!bigRoots && isInfused)
        {
            anim.SetTrigger("Is Infused");
            FunctionToDealDamages();
        }
        #endregion

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
            enemyCollision.GetComponent<LivingClass>().TakeDamages(Damage);
        }
    }
}
