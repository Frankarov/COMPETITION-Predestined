using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAutoNoTPNew : MonoBehaviour
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


        if (dialogueManagerScript.MasukDialogue == 0 && MasukTriggerAuto == 1 && dialogueManagerScript.izinAuto == 1)
        {
            Debug.Log("F Pressed");
            audioPlayerBug.Stop();
            Packet();
            //optionCountScript.MulaiHitung();

        }//closeif


    }

    public void Packet()
    {
        StartConvo();
        dialogueManagerScript.MasukDialogue = 1;
        dialogueManagerScript.bolehJalan = 0;
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
