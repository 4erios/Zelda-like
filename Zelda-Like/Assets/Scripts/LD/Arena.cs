using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField]
    private int arenaNumber;
    private bool arenaActif = true;
    public GameObject spawnerGroup;
    private bool chActif = false;
    public GameObject chForce;
    public int nbWaves = 1;
    private int countwaves = 0;

    [Header("Have a Mini-Boss ?")]
    public bool haveMiniBoss = false;
    public GameObject spawnerMiniBoss;
    public int miniBossWave;

    private void Start()
    {
        if (GameObject.Find("Areas Manager").GetComponent<ArenasManager>().arenasState[arenaNumber])
        {
            arenaActif = true;
        }

        else
            arenaActif = false;

        spawnerGroup.SetActive(false);
        spawnerMiniBoss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D traped)
    {
        if (arenaActif)
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
        if (GameObject.FindGameObjectsWithTag("Arena Enemy").Length == 0)
        {
            if (countwaves == miniBossWave && haveMiniBoss)
            {
                spawnerMiniBoss.SetActive(true);
            }

            else if (countwaves >= nbWaves)
            {
                spawnerMiniBoss.SetActive(false);
                GameObject.Find("Arenas Manager").GetComponent<ArenasManager>().arenasState[arenaNumber] = false;
                chForce.SetActive(false);
                chActif = false;
                spawnerGroup.SetActive(false);
                arenaActif = false;
            }

            else
            {
                spawnerMiniBoss.SetActive(false);
                countwaves++;
                spawnerGroup.GetComponentInChildren<Spawner>().LaunchRespawn();
            }
        }
    }
}
