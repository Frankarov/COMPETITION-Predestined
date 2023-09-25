using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation convo;
    public DialogueManager dialogueManagerScript;
    public OptionCount optionCountScript;
    private int MasukTrigger = 0;
    private int dialogueTriggerDone = 0;
    //private int MasukDialogue = 0;

    public GameObject visualCue;

    public AudioSource audioPlayerBug;


    private void Update()
    {
        if (dialogueManagerScript.MasukDialogue == 0 && MasukTrigger == 1 && Input.GetKeyDown(KeyCode.F)  && dialogueTriggerDone == 0)
        {
            Debug.Log("F Pressed");
            StartConvo();


            dialogueManagerScript.MasukDialogue = 1;
            dialogueManagerScript.bolehJalan = 0;
            optionCountScript.MulaiHitung();
            dialogueTriggerDone = 1;


            audioPlayerBug.Stop();

        }//closeif

        if(dialogueTriggerDone == 1)
        {
            visualCue.SetActive(false);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dialogueManagerScript.MasukDialogue == 0 && dialogueTriggerDone == 0)
        {
            visualCue.SetActive(true);
            MasukTrigger = 1;

        }//closeif



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualCue.SetActive(false);
            MasukTrigger = 0;
        }//closeif


    }

    private void StartConvo()
    {
        Debug.Log("StartConvo");
        DialogueManager.StartConversation(convo);
    }


}
