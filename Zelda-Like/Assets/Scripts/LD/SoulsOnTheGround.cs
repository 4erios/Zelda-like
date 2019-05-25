using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsOnTheGround : MonoBehaviour
{
    public FloatReference soulsLooted;

    public void GiveSouls()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSouls>().TakeSouls(soulsLooted);
    }
}
