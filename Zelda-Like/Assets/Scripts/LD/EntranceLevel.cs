using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceLevel : MonoBehaviour
{
    public int nbWay;
    private GameObject player;
    public GameEvent revive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player.GetComponentInChildren<LastScene>().lastScene == nbWay)
        {
            player.transform.position = this.transform.position;

            if(nbWay == 0)
            {
                revive.Raise();
            }
        }
    }

    public void Revive()
    {
        if (player.GetComponentInChildren<LastScene>().lastScene == 0)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerControls>().enabled = false;
            player.transform.position = this.transform.position;
            player.GetComponent<Animator>().SetTrigger("ResurrectionReallyDead");
        }
    }

    public void PlayerBegin()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerControls>().enabled = true;
    }
}
