using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemis_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeHP;
    private float percentHP;
    public GameObject ennemi;

    public FloatReference ennemiMaxHP;
    private LivingClass currentEnnemiHP;

    void Start()
    {
        percentHP = 1F;
        currentEnnemiHP = ennemi.GetComponent<LivingClass>();
    }

    void Update()
    {
        percentHP = currentEnnemiHP.health / ennemiMaxHP;

        gaugeHP.fillAmount = percentHP;
    }
}
