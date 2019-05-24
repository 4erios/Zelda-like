using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField]
    private int areaNumber;
    private bool areaActif = true;
    public GameObject spawnerGroup;
    private bool chActif = false;
    public GameObject chForce;
    public int nbWaves = 1;
    private int countwaves = 0;

    private void Start()
    {
        if (GameObject.Find("Area Manager").GetComponent<AreaManager>().areaState[areaNumber])
        {
            areaActif = true;
        }

        else
            areaActif = false;
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
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Area Enemy").Length == 0)
        {
            if (countwaves >= nbWaves)
            {
                GameObject.Find("Area Manager").GetComponent<AreaManager>().areaState[areaNumber] = false;
                chForce.SetActive(false);
                chActif = false;
                spawnerGroup.SetActive(false);
                areaActif = false;
            }

            else
            {
                countwaves++;
                //Active Waves
            }
        }
    }
}
