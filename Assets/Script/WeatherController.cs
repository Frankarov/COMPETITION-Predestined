using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    //GameObject
    public GameObject badai;
    public GameObject siang;

    public GameObject backgroundBadai;
    public GameObject backgroundSiang;

    public GameObject cahayaBadai;
    public GameObject cahayaSiang;

    public GameObject ilahiBadai;
    public GameObject ilahiSiang;

    //Script
    public GameTimer gameTimerScript;

    private void Update()
    {
        if(gameTimerScript.startingTimeSecond == 360)
        {
            StartCoroutine(BadaiMulai());
        }
        if(gameTimerScript.startingTimeSecond == 329)
        {
            StartCoroutine(BadaiBerhenti());
        }
    }

    private IEnumerator BadaiMulai()
    {
        yield return new WaitForSeconds(1);
        siang.SetActive(false);
        backgroundSiang.SetActive(false);
        cahayaSiang.SetActive(false);
        ilahiSiang.SetActive(false);


        badai.SetActive(true);
        backgroundBadai.SetActive(true);
        cahayaBadai.SetActive(true);
        ilahiBadai.SetActive(true);
    }

    private IEnumerator BadaiBerhenti()
    {
        yield return new WaitForSeconds(1);
        siang.SetActive(true);
        backgroundSiang.SetActive(true);
        cahayaSiang.SetActive(true);
        ilahiSiang.SetActive(true);



        badai.SetActive(false);
        backgroundBadai.SetActive(false);
        cahayaBadai.SetActive(false);
        ilahiBadai.SetActive(false);
    }

}
