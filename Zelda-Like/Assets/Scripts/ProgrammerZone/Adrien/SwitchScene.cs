﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene("LevelName");



        }
    }




}
