using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champ_de_Force : MonoBehaviour
{
    public bool actif = false;
    public GameObject chForce;

    private void OnTriggerEnter2D(Collider2D trap)
    {
        if (!actif && trap.tag == "Player")
        {
            chForce.SetActive(true);
            actif = true;
        }

        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            chForce.SetActive(false);
            actif = false;
        }
    }
}
