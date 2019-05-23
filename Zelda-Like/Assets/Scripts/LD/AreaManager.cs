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


    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
