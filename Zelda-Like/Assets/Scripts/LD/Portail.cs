using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portail : MonoBehaviour
{
    public bool attack = false;

    private float countDamage;
    [SerializeField]
    private float portailLife = 5;
    private Animator anim;
    private int ennemieSelected;
    private int areaSelected;
    public float timeBeforeRespawn = 15f;
    public GameObject[] ennemis; // Préfabs
    public GameObject[] spawnAreas;
    private GameObject ennemiObj;

    private void Start()
    {
        StartCoroutine(Respawn());
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (countDamage == portailLife)
        {
            anim.SetTrigger("Destroy");
        }

        if (attack)
        {
            countDamage++;
            attack = false;
        }
    }

    private void Roulette()
    {
        ennemieSelected = Random.Range(0, ennemis.Length);
        areaSelected = Random.Range(0, spawnAreas.Length);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeBeforeRespawn);
        Roulette();
        ennemiObj = Instantiate(ennemis[ennemieSelected], spawnAreas[areaSelected].transform.position, Quaternion.identity) as GameObject;
        StartCoroutine(Respawn());
    }
}
