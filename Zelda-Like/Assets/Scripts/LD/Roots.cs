using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    //Reste à faire :
    // - Annimation détruit
    // - Animation grossi
    // - Dégâts ennemis
    // - Activer collider

    public bool insufl = false;
    public bool attack = false;

    public bool bigRoots = false;
    [SerializeField]
    private float bigRootsLife = 3;
    private float countDamage;

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
        }
        #endregion

        #region Small
        if (!bigRoots && insufl)
        {
            //Anim
            //Dégâts zone
            //Activer collider
        }
        #endregion
    }
}
