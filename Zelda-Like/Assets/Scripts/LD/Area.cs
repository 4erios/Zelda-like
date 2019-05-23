using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField]
    private string areaName;
    private bool areaActif = true;
    public GameObject spawnerGroup;
    public bool chActif = false;
    public GameObject chForce;

    private void Start()
    {
        //Actif or not, here
    }

    private void OnTriggerEnter2D(Collider2D traped)
    {
        if (areaActif)
        {
            if (!chActif && traped.tag == "Player")
            {
                chForce.SetActive(true);
                chActif = true;
                spawnerGroup.SetActive(true);
            }

            if(GameObject.FindGameObjectsWithTag("Area Enemy").Length == 0)
            {
                chForce.SetActive(false);
                chActif = false;
                spawnerGroup.SetActive(false);
                areaActif = false;
            }
        }

    }
}
