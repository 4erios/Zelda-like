using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : GameMenu
{
    public GameObject player;

    public void Resume()
    {
        player.GetComponent<ESCMenu>().BPressed();
    }
}
