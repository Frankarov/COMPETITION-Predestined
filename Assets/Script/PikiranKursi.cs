using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikiranKursi : MonoBehaviour
{

    //script
    public GameTimer gameTimerScript;

    //GameObject
    public GameObject pikiranKursi;

    private void Update()
    {
        if(gameTimerScript.startingTimeSecond == 364)
        {
            StartCoroutine(Pikir());
        }

        if(gameTimerScript.startingTimeSecond == 14)
        {
            StartCoroutine(Pikir());
        }

    }

    private IEnumerator Pikir()
    {
        pikiranKursi.SetActive(true);
        yield return new WaitForSeconds(2);
        pikiranKursi.SetActive(false);
    }


}
