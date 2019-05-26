using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDisabler : MonoBehaviour
{



    public GameObject Object;
    public bool Disabler = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Object.SetActive(false);


    }
}
