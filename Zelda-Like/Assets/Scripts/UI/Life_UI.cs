using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeHP;

    public FloatReference playerMaxHP;
    public FloatVariable currentHP;

    private float percentHP;

    void Start()
    {
        percentHP = 1F;
    }

    void Update()
    {
        percentHP = currentHP / playerMaxHP;

        gaugeHP.fillAmount = percentHP;
    }


}
