using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerAbilities : MonoBehaviour
{
    public float DashRange;

    public Rigidbody2D rb;

    private float moveX;
    private float moveY;

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");



        if (Input.GetButtonDown("ButtonA"))
        {
            Vector2 direction = new Vector2(moveX, moveY);
            rb.AddForce(direction * DashRange);

            Debug.Log(direction);
        }
    }


}
