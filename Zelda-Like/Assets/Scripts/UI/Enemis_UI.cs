using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemis_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeHP;
    private float percentHP;

    public FloatReference ennemiMaxHP;
    public LivingClass ennemi;

    void Start()
    {
        percentHP = 1F;
    }

    void Update()
    {
        percentHP = ennemi.health / ennemiMaxHP;

        gaugeHP.fillAmount = percentHP;
    }
}
