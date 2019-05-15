using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_UI : MonoBehaviour
{
    public GameObject gOEnergyGauge;
    private Image gaugeEnergy;
    public Sprite[] energyElements;

    public IntVariable EnergyGauge;


    void Start()
    {
        gaugeEnergy = gOEnergyGauge.GetComponent<Image>();
        gaugeEnergy.sprite = energyElements[7];
    }

    private void Update()
    {
        if (EnergyGauge > 0)
        {
            gOEnergyGauge.SetActive(true);
            gaugeEnergy.sprite = energyElements[EnergyGauge - 1];
        }

        else
        gOEnergyGauge.SetActive(false);
        
    }




}
