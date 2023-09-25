using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAuto : MonoBehaviour
{
    // INI YANG BISA TP

    public Conversation convo;
    public AudioSource audioPlayerBug;
    public DialogueManager dialogueManagerScript;
    public OptionCount optionCountScript;
    private int MasukTriggerAuto = 0;
    //private int MasukDialogue = 0;

    public GameObject targetPlayer;
    public Animator animatorLoadingHitam;
    public GameObject visualCue;

 


    private void Update()
    {

        if(dialogueManagerScript.izinAuto == 0 && MasukTriggerAuto == 1)
        {
            Debug.Log("mauTransport");
            StartCoroutine(gasTransport());

        }

        if (dialogueManagerScript.MasukDialogue == 0 && MasukTriggerAuto == 1 && dialogueManagerScript.izinAuto == 1)
        {
            Debug.Log("F Pressed");
            StartConvo();
            dialogueManagerScript.MasukDialogue = 1;
            dialogueManagerScript.bolehJalan = 0;
            audioPlayerBug.Stop();
            //optionCountScript.MulaiHitung();

        }//closeif


    }

    IEnumerator gasTransport()
    {
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(1);
        targetPlayer.transform.position = new Vector3(18f, -1.33f, 0f);
        yield return new WaitForSeconds(1);
        animatorLoadingHitam.SetBool("LoadingHitam", false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dialogueManagerScript.MasukDialogue == 0)
        {
            visualCue.SetActive(true);
            MasukTriggerAuto = 1;
            dialogueManagerScript.identify = 2;


        }//closeif


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualCue.SetActive(false);
            MasukTriggerAuto = 0;
            dialogueManagerScript.izinAuto = 1;
            dialogueManagerScript.identify = 0;
        }//closeif


    }

    private void StartConvo()
    {
        Debug.Log("StartConvo");
        DialogueManager.StartConversation(convo);
    }



}
