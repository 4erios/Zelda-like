using UnityEngine.Audio;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator playerAnimator;

    public FloatVariable MoveX;
    public FloatVariable MoveY;
    public FloatVariable CurrentSpeed;
    public FloatVariable PlayerCurrentHP;

    public IntVariable AttackCount;

    public BoolVariable Healing;
    public BoolVariable Shielding;

    void Update()
    {
        playerAnimator.SetFloat("MoveX", MoveX);
        playerAnimator.SetFloat("MoveY", MoveY);
        

        playerAnimator.SetFloat("Speed", CurrentSpeed);
        playerAnimator.SetInteger("AttackCount", AttackCount);

        playerAnimator.SetFloat("Health", PlayerCurrentHP);

        playerAnimator.SetBool("Heal", Healing);
    }

    public void LaunchAttackAnimation()
    {
        playerAnimator.SetTrigger("Attack");
        Debug.Log("Attack Animation");
    }

    public void LaunchDashAnimation()
    {
        playerAnimator.SetTrigger("Dash");
    }

    public void LaunchTakeDamageAnimation()
    {
        playerAnimator.SetTrigger("TakeDamage");
    }

    public void LaunchResurrectionAnimation()
    {
        playerAnimator.SetTrigger("Résurrection");
    }

    public void LaunchDeathAnimation()
    {
        playerAnimator.SetTrigger("Death");
    }

    public void LaunchShootAnimation()
    {
        playerAnimator.SetTrigger("Tir");
    }

    public void LaunchInsufflationAnimation()
    {
        playerAnimator.SetBool("Insufflation", true);
    }

    public void SetInsufflationConditionToFalse()
    {
        playerAnimator.SetBool("Insufflation", false);
    }

    public void LaunchHealAnimation()
    {
        playerAnimator.SetBool("Heal", true);
    }
    public void StopHealAnimation()
    {


        playerAnimator.SetBool("Heal", false);


    }

    public void LaunchShieldAnimation()
    {


        playerAnimator.SetTrigger("Shield");

    }
}
