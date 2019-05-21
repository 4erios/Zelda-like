using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeEnergy;

    public IntVariable currentEnergy;


    void Start()
    {
        gaugeEnergy.fillAmount = 1F;
    }

    private void Update()
    {
        gaugeEnergy.fillAmount = currentEnergy / 100;

    }




}
