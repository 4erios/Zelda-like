using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : GameMenu
{
    public int inputs;

    public void Resume()
    {
        SceneManager.LoadScene(play);
    }

    public void Inputs()
    {
        SceneManager.LoadScene(inputs);
    }

}
