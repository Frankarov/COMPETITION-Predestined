using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SusterGantianDialogue : MonoBehaviour
{

    //Script
    public DialogueManager dialogueManagerScript;
    public PlayableDirector timeLine;
    public PlayerCollide playerCollideScript;

    //Numeric
    private int gantian = 0;
    private int firstFunc = 0;
    private int secondFunc = 0;

    //Component
    public BoxCollider2D triggerSusterDialogue;
    public SpriteRenderer doctor;


    private void Update()
    {
        if(dialogueManagerScript.dokterSusterDatangSiap == 1 && firstFunc == 0)
        {
            gantian = 1;
            firstFunc = 1;
            doctor.flipX = false;
            timeLine.Play();
        }

        if(dialogueManagerScript.dokterSusterDatangSiap == 1 && gantian == 1 && secondFunc == 0)
        {
            StartCoroutine(FunctionSuster());
            secondFunc = 1;
            playerCollideScript.tagIndicator = 7100;
        }


    }

    private IEnumerator FunctionSuster()
    {
        yield return new WaitForSeconds(1);
        triggerSusterDialogue.enabled = true;
        yield return new WaitForSeconds(2f);
        triggerSusterDialogue.enabled = false;
    }


}
