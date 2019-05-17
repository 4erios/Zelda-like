using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : LivingClass
{
    //PlayerDetection
    //FacePlayer
    //MoveToPlayer
    //KnockBack
    //MessageSystem

    private bool playerDetected = false;

    public void PlayerDetection(Transform monsterPosition, float detectionRange, LayerMask playerLayer)
    {
        Collider2D detection = Physics2D.OverlapCircle(monsterPosition.position, detectionRange, playerLayer);
        if (detection != null)
        {
            playerDetected = true;
        }
    }

    public void MoveToPlayer(Transform playerPosition, float speed, float stopRange)
    {
        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.position, speed * Time.deltaTime);
    }


}
