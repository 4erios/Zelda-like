using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(PolygonCollider2D))]
public class CameraPriority : MonoBehaviour
{
    public GameObject areaCamera;

    private void Start()
    {
        this.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            areaCamera.GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            areaCamera.GetComponent<CinemachineVirtualCamera>().Priority = 9;
        }
    }
}
