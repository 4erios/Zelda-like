using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public string LevelName;
    public int index;
    private GameObject player;
    private Animator animTransition;
    public float TimeTransition = 1.5f; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponentInChildren<LastScene>().lastScene = SceneManager.GetActiveScene().buildIndex;
            animTransition = player.GetComponentInChildren<LastScene>().panelAnim;


            StartCoroutine(Loading());
            
            


        }


     
    }


    IEnumerator Loading()
    {

        animTransition.SetTrigger("End");
        yield return new WaitForSeconds(TimeTransition);
        SceneManager.LoadScene(index);
        Debug.Log("Je sors de la zone");
    }

}
