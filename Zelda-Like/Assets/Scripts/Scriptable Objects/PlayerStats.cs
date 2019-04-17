using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject 
{

    public float playerHealth;

    public float playerSpeed;
    public AnimationCurve playerAccelerationCurve;
}
