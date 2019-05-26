using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arena")
        {
            this.gameObject.tag = "Arena Enemy";
        }
    }
}
