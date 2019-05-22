using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public string LevelName;
    public int index;
    public GameObject Player;
    public Animator animTransition;
    public float TimeTransition = 1.5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            StartCoroutine(Loading());
            
            


        }


     
    }


    IEnumerator Loading()
    {

        animTransition.SetTrigger("End");
        yield return new WaitForSeconds(TimeTransition);
        SceneManager.LoadScene(index);
        SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName(LevelName));
        Debug.Log("Je sors de la zone");
    }

}
