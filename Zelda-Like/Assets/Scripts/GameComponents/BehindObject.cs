using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindObject : MonoBehaviour
{
    private int orderLayer;
    private SpriteRenderer compSprite;
    private int saveOrderLayer;
    public bool inFrontOf;
    public int décalage = 5;

    void Start()
    {
        compSprite = gameObject.GetComponentInParent<SpriteRenderer>();
        saveOrderLayer = compSprite.sortingOrder;
        if(this.gameObject.GetComponent<BoxCollider2D>())
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        if(this.gameObject.GetComponent<PolygonCollider2D>())
        this.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        orderLayer = collision.GetComponent<SpriteRenderer>().sortingOrder;
        if (inFrontOf)
        {
            compSprite.sortingOrder = orderLayer - décalage;
        }

        else
            compSprite.sortingOrder = orderLayer + décalage;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        compSprite.sortingOrder = saveOrderLayer;
    }
}
