using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialoguePertamaOn : MonoBehaviour
{
    //Script untuk onkan trigger DokterDialogue pas cutscene rumahsakit

    public BoxCollider2D colliderLoop0;
    public BoxCollider2D colliderLoop1;
    public DialogueManager dialogueManagerScript;
    public PlayerCollide playerCollideScript;

    private int loopIndex;

    private int firstFunc = 0;

    private void Start()
    {
        loopIndex = PlayerPrefs.GetInt("Loop");
        StartCoroutine(StartOn());

    }

    private void Update()
    {


        if(dialogueManagerScript.dokterSusterDatangSiap == 1 && firstFunc == 0)
        {
            firstFunc = 1;
        }
    }


    private IEnumerator StartOn()
    {
        yield return new WaitForSeconds(11);
        Debug.Log("TriggerDokterCutscene terbuka");
        if(loopIndex == 0)
        {
            colliderLoop0.enabled = true;
            yield return new WaitForSeconds(2);
            colliderLoop0.enabled = false;

        }else if(loopIndex == 1)
        {
            colliderLoop1.enabled = true;
            yield return new WaitForSeconds(2);
            colliderLoop1.enabled = false;

        }

        playerCollideScript.tagIndicator = 7000;
    }


}
