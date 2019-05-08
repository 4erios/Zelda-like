using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    public FloatVariable moveX;
    public FloatVariable moveY;

    public float time = 1f;

    void Update()
    {
        playerAnimator.SetFloat("MoveX", moveX);
        playerAnimator.SetFloat("MoveY", moveY);
    }

    public IEnumerator TimeBetwinAttacks(float time)
    {
        yield return new WaitForSeconds(time);
        playerAnimator.SetBool("Attack", false);
    }

    public void Attack()
    {
        playerAnimator.SetBool("Attack", true);
        Debug.Log("Attack");
        StartCoroutine("TimeBetwinAttacks", time);
    }
    
}
