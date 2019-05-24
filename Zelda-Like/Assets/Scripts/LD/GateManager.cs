using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public FloatReference maxSoulsStepe1;
    public FloatVariable currentSouls;

    public bool bossHere;
    public bool ResetSouls;
    public GameObject gateCanvas;
    public GameObject boss1;

    private void Awake()
    {
        if (ResetSouls)
            currentSouls.SetFloatValue(0);
    }

    public void TakeSouls(float soulsValue)
    {
        currentSouls.ApplyChangeToFloat(soulsValue);

        if (currentSouls >= maxSoulsStepe1)
        {
            currentSouls.SetFloatValue(maxSoulsStepe1);
            bossHere = true;
            boss1.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            gateCanvas.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            gateCanvas.SetActive(false);
    }

    private void Update()
    {
        if (bossHere)
            gateCanvas.SetActive(false);
    }
}
