﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Portail : LivingClass
{
    private Animator anim;
    private int ennemieSelected;
    private int areaSelected;
    public float timeBeforeRespawn = 15f;
    public GameObject[] ennemis; // Préfabs
    public GameObject[] spawnAreas;
    private GameObject ennemiObj;
    public bool activation = false; 


    private void Start()
    {
        doesItGiveEnergy = true;
        StartCoroutine(Respawn());
        anim = this.gameObject.GetComponent<Animator>();
        
    }

    void Update()
    {
        if (health <= 0)
        {
            StopCoroutine(Respawn());
            anim.SetTrigger("Destroy");
        }

        if (takeDamages)
        {
            anim.SetTrigger("Damage");
            takeDamages = false;
        }

       


    }

    
    private void Roulette()
    {
        ennemieSelected = Random.Range(0, ennemis.Length);
        areaSelected = Random.Range(0, spawnAreas.Length);
        anim.SetTrigger("Invoke");
    }
    

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

   
    IEnumerator Respawn()
    {
        
        yield return new WaitForSeconds(timeBeforeRespawn);
        if (activation) {
            Roulette();
            ennemiObj = Instantiate(ennemis[ennemieSelected], spawnAreas[areaSelected].transform.position, Quaternion.identity) as GameObject;
        }
        StartCoroutine(Respawn());
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            activation = true; 
            anim.SetTrigger("Activation");




        }
    }
}
