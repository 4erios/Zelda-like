using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Souls_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeSouls;

    //public FloatReference playerMaxSouls;
    //public FloatVariable currentSouls;

    private float percentSouls;

    void Start()
    {
        percentSouls = 0F;
    }

    void Update()
    {
        //percentSouls = currentSouls / playerMaxSouls;

        gaugeSouls.fillAmount = percentSouls;
    }
}
