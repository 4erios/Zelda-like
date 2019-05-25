using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenasManager : MonoBehaviour
{
    public bool[] arenasState;

    #region Arena Repertory
    // 0 P1A3
    // 1 P1A4
    #endregion

    public void ResetArenas()
    {
        for (int i = 0; i < arenasState.Length; i++)
        {
            arenasState[i] = false;
        }
    }
}
