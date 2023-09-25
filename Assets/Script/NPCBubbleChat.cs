using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBubbleChat : MonoBehaviour
{

    //GameObject
    public GameObject bubble1;
    public GameObject bubble2;

    //Script
    public GameTimer gameTimerScript;

    private void Update()
    {
        if(gameTimerScript.startingTimeSecond == 353)
        {
            StartCoroutine(Bubble1Keluar());
        }

        if(gameTimerScript.startingTimeSecond == 348)
        {
            StartCoroutine(Bubble2Keluar());
        }
    }

    private IEnumerator Bubble1Keluar()
    {
        bubble1.SetActive(true);
        yield return new WaitForSeconds(3);
        bubble1.SetActive(false);
    }

    private IEnumerator Bubble2Keluar()
    {
        bubble2.SetActive(true);
        yield return new WaitForSeconds(3);
        bubble2.SetActive(false);
    }


}
