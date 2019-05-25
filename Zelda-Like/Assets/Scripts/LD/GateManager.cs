using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public FloatReference maxSoulsStepe1;
    public FloatVariable currentGateSouls;
    public FloatVariable currentPlayerSouls;
    public IntVariable playerCount;

    public Animator animatorGauge;

    public bool bossHere;
    public bool ResetSouls;
    public bool giveSouls = false;
    public GameObject gateCanvas;
    public GameObject boss1;

    private void Awake()
    {
        if (ResetSouls)
            currentGateSouls.SetFloatValue(0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gateCanvas.SetActive(true);
            if (gateCanvas.activeInHierarchy)
            {
                playerCount.SetIntValue(3);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gateCanvas.SetActive(false);
            playerCount.SetIntValue(0);
        }

    }

    private void Update()
    {
        if (bossHere)
            gateCanvas.SetActive(false);

        giveSouls = false;

        animatorGauge.SetBool("Active", giveSouls);
    }

    public void SoulsToGate()
    {
        if (gateCanvas.activeInHierarchy && currentPlayerSouls >= 5)
        {
            animatorGauge.SetBool("Active", true);
            currentGateSouls.ApplyChangeToFloat(5 * Time.timeScale);
            currentPlayerSouls.ApplyChangeToFloat(-5 * Time.timeScale);

            if (currentGateSouls >= maxSoulsStepe1)
            {
                currentGateSouls.SetFloatValue(maxSoulsStepe1);
                boss1.SetActive(true);
                bossHere = true;
            }
        }
    }
}
