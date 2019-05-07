using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    public FloatReference PlayerAttackDamages;
    public FloatReference AttackRange;


    [Header("Energy Parameters")]
    public FloatVariable EnergyTank;

    public IntVariable CurrentEnergy;
    public IntReferences EnergyMax;

    

}
