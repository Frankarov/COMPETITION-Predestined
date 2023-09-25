using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    //Numeric
    [SerializeField]
    private int badaiBosKu = 0;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float ShakeIntensity;
    private float ShakeTime = 10f;

    //Script
    public GameTimer gameTimerScript;
    private CinemachineBasicMultiChannelPerlin CBMP;

    //Camera
    private CinemachineVirtualCamera CVC;

    private void Awake()
    {
        CVC = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        StopShake();
        gameTimerScript = FindObjectOfType<GameTimer>();
    }

    private void StartShake()
    {
        CinemachineBasicMultiChannelPerlin CBMP = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CBMP.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin CBMP = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CBMP.m_AmplitudeGain = 0f;

        timer = 0;
    }

    private void Update()
    {



        if (gameTimerScript.startingTimeSecond == 359)
        {
            ShakeTime = 30f;
            ShakeIntensity = 0.5f;
            StartShake();
            badaiBosKu = 1;
            StartCoroutine(VariousStorm());
        }

        if(gameTimerScript.startingTimeSecond == 123)
        {
            ShakeTime = 3;
            ShakeIntensity = 100f;
            StartShake();
        }

        if (timer>0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                StopShake() ;
                badaiBosKu = 0;
            }
        }

    }

    private IEnumerator VariousStorm()
    {

        yield return new WaitForSeconds(3);

        ShakeIntensity = 0.8f;

        yield return new WaitForSeconds(2);
        ShakeIntensity = 1f;

        yield return new WaitForSeconds(2);

        ShakeIntensity = 0.6f;

        yield return new WaitForSeconds(3);

        ShakeIntensity = 0.3f;

        yield return new WaitForSeconds(2);

        ShakeIntensity = 0.5f;

        yield return new WaitForSeconds(1);
        ShakeIntensity = 0.7f;

        yield return new WaitForSeconds(2);
        ShakeIntensity = 1f;

        yield return new WaitForSeconds(2);

        ShakeIntensity = 1.5f;

        yield return new WaitForSeconds(2);
        ShakeIntensity = 2f;

        yield return new WaitForSeconds(4);
        Debug.Log("Storm!!!");
        ShakeIntensity = 70f;


        yield return new WaitForSeconds(2);
        ShakeIntensity = 2f;

        yield return new WaitForSeconds(1);
        ShakeIntensity = 1f;

        yield return new WaitForSeconds(1);
        ShakeIntensity = 0.5f;

        yield return new WaitForSeconds(1);
        ShakeIntensity = 0.2f;

    } //close VariousStorm


}
