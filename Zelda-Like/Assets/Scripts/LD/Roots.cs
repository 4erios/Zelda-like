using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    //Reste à faire :
    // - Dégâts ennemis

    public bool isInfused = false;
    public bool attack = false;

    
    public bool bigRoots = false;
    private Animator anim;
    [SerializeField]
    private float bigRootsLife = 3;
    private float countDamage;

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
            //Dégâts zone
        }
        #endregion

    }

    public void ChangeState()
        {
            bigRoots = !bigRoots;
        }
}
