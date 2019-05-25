using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraArea : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<CinemachineConfiner>().m_BoundingShape2D = this.gameObject.GetComponent<PolygonCollider2D>();
    }
}
