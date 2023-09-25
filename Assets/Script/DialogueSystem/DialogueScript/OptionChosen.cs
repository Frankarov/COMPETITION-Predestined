using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionChosen : MonoBehaviour
{
    public OptionCount optionCountScript;
    public OptionShow optionShowScript;
    public Conversation convo;
    public GameObject otherButton;
    public GameObject otherButton2;
    public GameObject otherButton3;
    public DialogueManager dialogueManagerScript;
    public PlayerCollide playerCollideScript;

    public AudioSource sfxButton;
    private void Start()
    {
        //optionCountScript = FindObjectOfType<OptionCount>();
        //optionShowScript = FindObjectOfType<OptionShow>();

    }

    public void startConvo()
    {

    }

    public void ButtonChosen()
    {
        sfxButton.Play();
        gameObject.SetActive(false);
        otherButton.SetActive(false);
        otherButton2.SetActive(false);
        otherButton3.SetActive(false);
        DialogueManager.StartConversation(convo);
        //optionCountScript.countOptionCheck = 0;
        dialogueManagerScript.countOptionCheck = 0;
        dialogueManagerScript.buttonTouched = 0;

        optionShowScript.OptionMuncul = 0;
        //playerCollideScript.tagIndicator = 0;


    }
}
