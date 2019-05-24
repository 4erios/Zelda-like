using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfusableClass : LivingClass
{
    public bool isInfused = false;

    public void Infuse()
    {
        isInfused = true;
    }

}
