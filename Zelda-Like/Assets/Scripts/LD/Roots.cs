using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    //Reste à faire :
    // - Annimation détruit
    // - Animation grossi
    // - Dégâts ennemis

    public bool insufl = false;
    public bool attack = false;

    public bool bigRoots = false;
    [SerializeField]
    private float bigRootsLife = 3;
    private float countDamage;

    private void Start()
    {
        if (bigRoots)
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
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
            // Anim Destroy
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            bigRoots = false;
        }
        #endregion

        #region Small
        if (!bigRoots && insufl)
        {
            //Anim
            //Dégâts zone
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
        #endregion
    }
}
