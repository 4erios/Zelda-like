using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindObject : MonoBehaviour
{
    private int orderLayer;
    private Transform player;
    public Transform centerPosition;
    private SpriteRenderer compSprite;

    void Start()
    {
        compSprite = this.gameObject.GetComponent<SpriteRenderer>();
        orderLayer = compSprite.sortingOrder;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (player.position.y > centerPosition.position.y)
        {
            compSprite.sortingOrder = -orderLayer;
        }

        else
        {
            compSprite.sortingOrder = orderLayer;
        }
    }
}
