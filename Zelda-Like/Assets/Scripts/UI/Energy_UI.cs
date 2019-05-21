using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_UI : MonoBehaviour
{
    [SerializeField]
    private Image gaugeEnergy;

    public IntVariable EnergyMax;
    public IntVariable currentEnergy;

    private float percentEnergy;

    void Start()
    {
        percentEnergy = 1F;
    }

    private void Update()
    {
        percentEnergy = currentEnergy / EnergyMax;
        gaugeEnergy.fillAmount = percentEnergy;
    }




}
