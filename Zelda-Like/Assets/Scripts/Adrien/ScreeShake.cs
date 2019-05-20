using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class ScreeShake : MonoBehaviour
{
    public float ShakeDuration = 0.3f;
    public float ShakeAmplitude = 1.2f;
    public float ShakeFrequency = 2.0f;
    public bool ScreenShakeActivation;
    private float ShakeElapsedTime = 0f;

    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise; 




    // Start is called before the first frame update

    void Start()
    {
        if (VirtualCamera != null)
        {

            virtualCameraNoise = VirtualCamera.GetCinemachineComponent <Cinemachine.CinemachineBasicMultiChannelPerlin>();

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ScreenShakeActivation == true)
        {


            virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
            virtualCameraNoise.m_FrequencyGain = ShakeFrequency;



        }

        else
         {

                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;

         }

    }

    public void ScreenShake ()
    {

        ShakeElapsedTime = ShakeDuration;



        if (ScreenShakeActivation == true)
        {
            

                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

           
            /*else
            {

                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;

            }*/



        }






    }



    public void StartScreenShake()
    {


        ScreenShakeActivation = true;



    }

    public void StopScreenShake()
    {



        ScreenShakeActivation = false;


    }


}
