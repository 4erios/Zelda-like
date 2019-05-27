using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDebugScript : MonoBehaviour
{
    private bool disableCollider = false;
    public Collider2D collider1;
    //public Collider2D collider2;

    // Update is called once per frame
    void Update()
    {
        PressDebugTouch();
        DisableCollider();
    }

    public void DisableCollider()
    {
        if (disableCollider == false)
        {
            collider1.enabled = true;
            //collider2.enabled = true;
        }
        else if (disableCollider == true)
        {
            collider1.enabled = false;
            //collider2.enabled = false;
        }
    }

    public void PressDebugTouch()
    {
        if (Input.GetKeyDown("P"))
        {
            if (disableCollider == false)
            {
                disableCollider = true;
            }
            else if (disableCollider == true)
            {
                disableCollider = false;
            }
        }

    }

}
