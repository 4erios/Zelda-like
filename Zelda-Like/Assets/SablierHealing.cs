using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SablierHealing : MonoBehaviour
{
    // Start is called before the first frame update
    public BoolVariable HealingBool;
    public Animator Sablier; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sablier.SetBool("Healing", HealingBool);
    }
}
