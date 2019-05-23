using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemis_UI : MonoBehaviour
{
    public GameObject ennemie;
    [SerializeField]
    private Image gaugeHP;
    private float percentHP;

    public FloatReference enemieMaxHP;
    public FloatVariable currentEnnemieHP;

    void Start()
    {
        percentHP = 1F;
    }

    void Update()
    {
        //percentHP = currentHP / playerMaxHP;

        gaugeHP.fillAmount = percentHP;
    }
}
