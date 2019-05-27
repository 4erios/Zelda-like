using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_Dead : MonoBehaviour
{
    public bool reallyDead;
    private Animator animTransition;

    [Header("Reset")]
    public FloatReference maxHP;
    public FloatVariable currentHP;
    public IntVariable currentEnergy;
    public FloatVariable currentSouls;
    public GameObject arenasManager;
    public float TimeTransition = 1.5f;
    public int gateScene;

    private void Start()
    {
        animTransition = arenasManager.GetComponent<LastScene>().panelAnim;
    }

    void Update()
    {
        if (reallyDead)
        {
            ReallyDead();
        }
    }

    public void ReallyDead()
    {
        currentHP.SetFloatValue(maxHP);
        currentEnergy.SetIntValue(80);
        currentSouls.SetFloatValue(0);
        arenasManager.GetComponent<ArenasManager>().ResetArenas();
        arenasManager.GetComponent<LastScene>().lastScene = 0;
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        reallyDead = false;
        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        this.gameObject.GetComponent<PlayerControls>().enabled = false;
        animTransition.SetTrigger("End");
        yield return new WaitForSeconds(TimeTransition);
        SceneManager.LoadScene(gateScene);
    }
}
