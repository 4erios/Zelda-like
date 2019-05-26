using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampCamera : MonoBehaviour
{

    public Camera playerCamera;
    public float XMaxValue;
    public float YMaxValue;
    public bool ClampX;
    public bool ClampY;
    public bool CampXEnabled;
    public bool ClampYEnabled;
    public float cameraPosX;
    public float cameraPosY;

   /* public float cameraPosX()
    {
        return playerCamera.transform.position.x;
    }
    public float cameraPosY()
    {
        return playerCamera.transform.position.y;
    }*/



    // Start is called before the first frame update
    void Start()
    {
        cameraPosX = playerCamera.transform.position.x;
        cameraPosY = playerCamera.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {


        



    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {


            if (ClampX == true)
            {
                XMaxValue = cameraPosX;
                Mathf.Clamp(cameraPosX, -1000, XMaxValue);
                Debug.Log("Clamp X");

            }

            if (ClampY == true)
            {
                YMaxValue = cameraPosY;
                Mathf.Clamp(cameraPosY, -1000, YMaxValue);
                Debug.Log("Clamp Y");
            }


        }

    }
}
