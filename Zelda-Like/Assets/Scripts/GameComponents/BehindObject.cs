using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindObject : MonoBehaviour
{
    private int orderLayer;
    private SpriteRenderer compSprite;
    private int saveOrderLayer;
    private bool objectBehind;

    void Start()
    {
        compSprite = gameObject.GetComponentInParent<SpriteRenderer>();
        saveOrderLayer = compSprite.sortingOrder;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        orderLayer = collision.GetComponent<SpriteRenderer>().sortingOrder;

        compSprite.sortingOrder = orderLayer + 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        compSprite.sortingOrder = saveOrderLayer;
    }
}
