using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikiranRussia : MonoBehaviour
{

    //Script
    public DialogueManager dialogueManagerScript;

    //GameObject
    public GameObject pikiranRussia;

    private void Update()
    {
        if(dialogueManagerScript.pikiranRussia == 1)
        {
            StartCoroutine(Pikir());
            dialogueManagerScript.pikiranRussia = 0;
        }
    }

    private IEnumerator Pikir()
    {
        pikiranRussia.SetActive(true);
        yield return new WaitForSeconds(2);
        pikiranRussia.SetActive(false);

    }

}
