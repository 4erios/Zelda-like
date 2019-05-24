using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSouls : MonoBehaviour
{
    public FloatReference maxSouls;
    public FloatVariable currentSouls;

    public bool ResetHP;
    public float magnetRange = 3f;

    private void Awake()
    {
        if (ResetHP)
            currentSouls.SetFloatValue(0);
    }

    public void TakeSouls(float soulsValue)
    {
        currentSouls.ApplyChangeToFloat(soulsValue);

        if (currentSouls >= maxSouls)
        {
            currentSouls.SetFloatValue(maxSouls);
        }
    }

    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Souls");

        Collider2D[] areaObj = Physics2D.OverlapCircleAll(this.gameObject.transform.position, magnetRange, mask);
        foreach (Collider2D obj in areaObj)
        {
            obj.GetComponent<SoulsOnTheGround>().GiveSouls();
            Destroy(obj.gameObject);
        }
    }
}
