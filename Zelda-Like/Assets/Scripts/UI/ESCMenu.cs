using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    public GameObject escapeMenu;
    public string nameInputButtonStart;
    public GameEvent pressStart;


    private void Update()
    {
        if (Input.GetButtonDown(nameInputButtonStart))
        {
            pressStart.Raise();
            Debug.Log("Startpush");
        }
    }

    public void StartPressed()
    {
        if (!escapeMenu.activeInHierarchy)
        {
                escapeMenu.SetActive(true);
                Time.timeScale = 0;
            Debug.Log("Startpush");
        }

        else if (escapeMenu.activeInHierarchy)
        {
                Continue();
        }
    }

    public void BPressed()
    {
        if (escapeMenu.activeInHierarchy)
        {
            Continue();
        }
    }

    public void Continue()
    {
        escapeMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
