using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_UI : MonoBehaviour
{
    public GameObject gOEnergyGauge;
    private Image gaugeEnergy;
    public Sprite[] energyElements;

    public IntVariable currentEnergy;

    void Start()
    {
        gaugeEnergy = gOEnergyGauge.GetComponent<Image>();
        gaugeEnergy.sprite = energyElements[7];
    }

    private void Update()
    {

        #region Energy Gauge System
        if (currentEnergy > 0)
            gOEnergyGauge.SetActive(true);

        if (currentEnergy > 70)
        {
            gaugeEnergy.sprite = energyElements[7];
        }

        else if (currentEnergy > 60)
        {
            gaugeEnergy.sprite = energyElements[6];
        }

        else if (currentEnergy > 50)
        {
            gaugeEnergy.sprite = energyElements[5];
        }

        else if (currentEnergy > 40)
        {
            gaugeEnergy.sprite = energyElements[4];
        }

        else if (currentEnergy > 30)
        {
            gaugeEnergy.sprite = energyElements[3];
        }

        else if (currentEnergy > 20)
        {
            gaugeEnergy.sprite = energyElements[2];
        }

        else if (currentEnergy > 10)
        {
            gaugeEnergy.sprite = energyElements[1];
        }

        else if (currentEnergy > 0)
        {
            gaugeEnergy.sprite = energyElements[0];
        }

        else
            gOEnergyGauge.SetActive(false);
        #endregion

    }




}
