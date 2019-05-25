using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Dead : MonoBehaviour
{
    public bool reallyDead;

    [Header("Reset")]
    public FloatReference maxHP;
    public FloatVariable currentHP;
    public FloatReference maxEnergy;
    public FloatVariable currentEnergy;
    public FloatVariable currentSouls;
    public GameObject arenasManager;
    public int gateScene;

    void Update()
    {
        if (reallyDead)
        {
            ReallyDead();
        }
    }

    public void ReallyDead()
    {
        currentHP.SetFloatValue(maxHP);
        currentEnergy.SetFloatValue(maxEnergy);
        currentSouls.SetFloatValue(0);
        arenasManager.GetComponent<ArenasManager>().ResetArenas();
    }
}
