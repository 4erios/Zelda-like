using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : LivingClass
{

    public override void Death()
    {
        Debug.Log("Player died!");
    }

    //Accélération au début du déplacement
    public void PlayerAccelerate(Rigidbody2D rb,float moveX, float moveY,float speed, AnimationCurve accelerationCurve)
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX*speed* accelerationCurve.Evaluate(Time.time), moveY * speed * accelerationCurve.Evaluate(Time.time));
    }

    //Déplacement à vitesse normale
    public void PlayerMove(Rigidbody2D rb, float moveX, float moveY, float speed)
    {
        //moveX = Input.GetAxis("Horizontal");
        //moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX * speed, moveY * speed);
    }

    //Attaque, utilisable dans les 4 directions; besoin potentiel d'avoir son propre script
    public void PlayerAttack(Transform AttackPoint, float attackRange,LayerMask enemiesLayer, float playerDamages)
    {
        Collider2D[] enemiesHurt = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange);
        for (int i=0; i < enemiesHurt.Length; i++)
        {
            enemiesHurt[i].GetComponent<LivingClass>().TakeDamages(playerDamages);
            Debug.Log("Ennemi touché");
            Debug.Log(i);
            //enemiesHurt[i].GetComponent<PlayerClass>().GainEnergy();  pb car besoin d'ajouter une variable float playerEnergyGain pour fonctionner avec la fonction GainEnergy
        }
    }

    //Energie et pouvoirs de l'énergie
    public float energyTank;

    public int maxEnergy;
    public int energy;

    public void LoseEnergy(int energyCost)
    {
        energy = energy - energyCost;
        if(energy < 0)
        {
            energy = 0;
        }
    }

    public void GainEnergy(float energyGain)
    {
        energyTank += energyGain;
        if (energyTank >= 100)
        {
            energy += 1;
            energyTank = 0;

            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
        }
    }

    public void PlayerDash(Rigidbody2D rb, float moveX, float moveY,float dashRange, int dashEnergyCost)
    {
        LoseEnergy(dashEnergyCost);

        Vector2 direction = new Vector2(moveX, moveY);
        rb.MovePosition(rb.position + direction * dashRange);
    }

    public void PlayerHeal(float playerHealth,float healValue, int healEnergyCost)
    {
        health = health + healValue;
        LoseEnergy(healEnergyCost);
        if (health >= playerHealth)
        {
            health = playerHealth;
        }
    }

    public IEnumerator TimeUntilDeath(float timeUntilDeath)
    {
        yield return new WaitForSeconds(timeUntilDeath);
        if (health <= 0)
        {
            Death();
        }
    }

    public void PlayerResurrect(int deathZone)
    {
        if (health <= 0 && energy > deathZone)
        {
            StartCoroutine("TimeUntilDeath");
        }
        else if(health <=0 && energy <= deathZone)
        {
            Death();
        }
    }


    
}
