using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemis_UI : MonoBehaviour
{
    public GameObject ennemi;
    [SerializeField]
    private Image gaugeHP;
    private float percentHP;

    public FloatReference ennemiMaxHP;
    public FloatVariable currentEnnemiHP;

    void Start()
    {
        percentHP = 1F;
    }

    void Update()
    {
        percentHP = currentEnnemiHP / ennemiMaxHP;

        gaugeHP.fillAmount = percentHP;
    }
}
