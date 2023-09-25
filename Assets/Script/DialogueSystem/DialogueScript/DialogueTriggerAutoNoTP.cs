using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAutoNoTP : MonoBehaviour
{

    public Conversation convo;
    public DialogueManager dialogueManagerScript;
    public OptionCount optionCountScript;
    private int MasukTriggerAuto = 0;
    //private int MasukDialogue = 0;

    public GameObject targetPlayer;

    public GameObject visualCue;
    public AudioSource audioPlayerBug;

    private void Update()
    {

 

        if (dialogueManagerScript.MasukDialogue == 0 && MasukTriggerAuto == 1)
        {
            Debug.Log("F Pressed");
            audioPlayerBug.Stop();
            Packet();


        }//closeif


    }

    public void Packet()
    {
        StartConvo();
        dialogueManagerScript.MasukDialogue = 1;
        dialogueManagerScript.bolehJalan = 0;
        optionCountScript.MulaiHitung();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dialogueManagerScript.MasukDialogue == 0)
        {
            Debug.Log("kena tagplayer");
            visualCue.SetActive(true);
            MasukTriggerAuto = 1;
            dialogueManagerScript.identify = 2;


        }//closeif

        if (collision.CompareTag("PlayerKardus3") && dialogueManagerScript.MasukDialogue == 0)
        {
            Debug.Log("kena tagplayer");
            visualCue.SetActive(true);
            MasukTriggerAuto = 1;
            dialogueManagerScript.identify = 2;


        }


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

        if (collision.CompareTag("PlayerKardus3"))
        {
            visualCue.SetActive(false);
            MasukTriggerAuto = 0;
            dialogueManagerScript.izinAuto = 1;
            dialogueManagerScript.identify = 0;
        }
    }

    private void StartConvo()
    {
        Debug.Log("StartConvo");
        DialogueManager.StartConversation(convo);
    }
}
