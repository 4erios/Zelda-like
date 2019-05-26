﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public int play;
    public int inputs;
    public EventSystem eS;
    private GameObject storeSelected;
    [SerializeField]
    private GameObject firstButton;

    // Start is called before the first frame update
    void Start()
    {
        storeSelected = firstButton;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (eS == null)
        {
            eS = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            storeSelected = firstButton;
        }

        if (eS.currentSelectedGameObject != storeSelected)
        {
            if (eS.currentSelectedGameObject == null)
            {
                eS.SetSelectedGameObject(storeSelected);
            }

            else
            {
                storeSelected = eS.currentSelectedGameObject;
            }
        }

        else
        {
            storeSelected = eS.firstSelectedGameObject;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(play);
    }

    public void Quit()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }

    public void Inputs()
    {
        SceneManager.LoadScene(inputs);
    }
}
