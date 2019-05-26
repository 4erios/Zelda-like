using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeahScript : MonoBehaviour

{

    public GameObject SoulToDrop;
    public GameObject Ennemi;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyLastMoments()
    {
        Instantiate(SoulToDrop, Ennemi.transform.position, Ennemi.transform.rotation);
    }

}
