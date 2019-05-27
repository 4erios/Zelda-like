using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hourglass_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeHourglass;

    public float maxTime = 3f;

    private float percentRemainingTime;
    public FloatVariable timeUntilDeath;

    void Start()
    {
        percentRemainingTime = 1F;
    }

    void Update()
    {
        percentRemainingTime = timeUntilDeath / maxTime;

        gaugeHourglass.fillAmount = percentRemainingTime;
    }
}
