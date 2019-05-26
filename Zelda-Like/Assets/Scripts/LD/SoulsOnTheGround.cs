using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsOnTheGround : MonoBehaviour
{
    public FloatReference soulsLooted;

    private void Start()
    {
        StartCoroutine(Maskk());
    }

    public void GiveSouls()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSouls>().TakeSouls(soulsLooted);
        Debug.Log("Récolté!");
    }

    IEnumerator Maskk()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.layer = 10;
    }
}
