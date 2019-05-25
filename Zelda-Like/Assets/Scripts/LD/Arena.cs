using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField]
    private int arenaNumber;
    [SerializeField]
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
        if (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArenasManager>().arenasState[arenaNumber])
        {
            arenaActif = true;
        }

        else
            arenaActif = false;
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
                countwaves++;
            }
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Arena Enemy").Length == 0 && countwaves > 0)
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
                countwaves++;
                spawnerGroup.GetComponentInChildren<Spawner>().LaunchRespawn();
            }
        }
    }
}
