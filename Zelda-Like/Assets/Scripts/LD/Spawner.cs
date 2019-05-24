using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ennemis; // Préfabs
    private int ennemieSelected;
    private GameObject ennemiObj;
    public int nbSpawn;
    private int countSpawn;

    private void Start()
    {
        do
        {
            Roulette();
            Respawn();
            countSpawn++;
        } while (countSpawn < nbSpawn);
    }

    public void LaunchRespawn()
    {
        countSpawn = 0;

        do
        {
            Roulette();
            Respawn();
            countSpawn++;
        } while (countSpawn < nbSpawn);
    }

    private void Respawn()
    {
        ennemiObj = Instantiate(ennemis[ennemieSelected], this.gameObject.transform.position, Quaternion.identity) as GameObject;
    }

    private void Roulette()
    {
        ennemieSelected = Random.Range(0, ennemis.Length);
    }
}
