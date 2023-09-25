using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePause: MonoBehaviour
{
    public OptionShow optionShowScript;

    public DialogueManager dialogueManagerScript;



    private void Start()
    {
       //dialogueManagerScript = FindObjectOfType<DialogueManager>();
       //optionShowScript = FindObjectOfType<OptionShow>();

    }
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && !dialogueManagerScript.complete)
        {
            dialogueManagerScript.interruptTyping = true;
        }else if (optionShowScript.OptionMuncul == 0 && Input.GetKeyDown(KeyCode.E) && dialogueManagerScript.complete == true)
        {
            Debug.Log("E Pressed");
            dialogueManagerScript.readNext();
        }


    }
}
