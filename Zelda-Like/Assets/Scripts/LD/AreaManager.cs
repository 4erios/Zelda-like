using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    #region Demarage
    public static AreaManager manager;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    #endregion

    public bool[] areaState;

    #region Area Repertory
    // 0 P1A3
    // 1 P1A4
    #endregion
}
