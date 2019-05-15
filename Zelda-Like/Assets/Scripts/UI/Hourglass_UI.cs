using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hourglass_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeHourglass;

    //public FloatReference playerMaxTime;

    private float percentRemainingTime;

    void Start()
    {
        percentRemainingTime = 1F;
    }

    void Update()
    {
        //percentRemainingTime = (playerMaxTime - time.deltaTime) / playerMaxTime;

        gaugeHourglass.fillAmount = percentRemainingTime;
    }
}
