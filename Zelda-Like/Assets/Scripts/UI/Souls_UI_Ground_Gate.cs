using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Souls_UI_Ground_Gate : MonoBehaviour
{
    [SerializeField]
    private Image gaugeGround;

    public FloatReference gateMaxSoulsStep1;
    public FloatVariable currentGateSouls;

    private float percentSouls;

    void Start()
    {
        percentSouls = 0F;
    }

    void Update()
    {
        percentSouls = currentGateSouls / gateMaxSoulsStep1;

        gaugeGround.fillAmount = percentSouls;
    }
}
