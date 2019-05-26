using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_UI : MonoBehaviour
{
    private int gaugeCount;
    private float currentEnergyFloat;
    public GameObject[] energyElements;

    public IntVariable currentEnergy;
    private float percentGaugeElement;


    private void Update()
    {
        for (int i = 0; i < energyElements.Length; i++)
        {
            energyElements[i].GetComponent<Image>().fillAmount = 0f;
        }

        #region Energy Gauge System
        if (currentEnergy > 70)
        {
            gaugeCount = 7;
            energyElements[7].GetComponent<Image>().fillAmount = percentGaugeElement;
        }

        else if (currentEnergy > 60)
        {
            gaugeCount = 6;
            energyElements[6].GetComponent<Image>().fillAmount = percentGaugeElement;
        }

        else if (currentEnergy > 50)
        {
            gaugeCount = 5;
            energyElements[5].GetComponent<Image>().fillAmount = percentGaugeElement;
        }

        else if (currentEnergy > 40)
        {
            gaugeCount = 4;
            energyElements[4].GetComponent<Image>().fillAmount = percentGaugeElement;
        }

        else if (currentEnergy > 30)
        {
            gaugeCount = 3;
            energyElements[3].GetComponent<Image>().fillAmount = percentGaugeElement;
        }

        else if (currentEnergy > 20)
        {
            gaugeCount = 2;
            energyElements[2].GetComponent<Image>().fillAmount = percentGaugeElement;
        }

        else if (currentEnergy > 10)
        {
            gaugeCount = 1;
            energyElements[1].GetComponent<Image>().fillAmount = percentGaugeElement;
        }

        else if (currentEnergy > 0)
        {
            gaugeCount = 0;
            energyElements[0].GetComponent<Image>().fillAmount = percentGaugeElement;
        }
        #endregion

            for (int i = 0; i < gaugeCount; i++)
            {
                energyElements[i].GetComponent<Image>().fillAmount = 1f;
            }

        currentEnergyFloat = currentEnergy;

        percentGaugeElement = (currentEnergyFloat - (gaugeCount * 10)) / 10;
    }




}
