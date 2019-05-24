using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRange : MonoBehaviour
{
    public Transform rangeCenter;
    public FloatReference rangeToShow;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rangeCenter.position, rangeToShow);
    }
}
