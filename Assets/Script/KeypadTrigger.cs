using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{

    //Script
    public DialogueManager dialogueManagerScript;

    //GameObject
    public GameObject visualCue;

    //Component
    public Animator animator;

    //Numeric
    private int keypadTriggerInt = 0;
    private int isPlayed = 0;



    private void Update()
    {
        if(keypadTriggerInt == 1 && Input.GetKeyDown(KeyCode.F) && isPlayed == 0)
        {
            Debug.Log("keypadkebuka");
            KeypadOpen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualCue.SetActive(true);
            keypadTriggerInt = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualCue.SetActive(false);
            keypadTriggerInt = 0;
        }
    }

    public void KeypadOpen()
    {
        dialogueManagerScript.bolehJalan = 0;
        animator.SetBool("KeypadOpening",true);
        isPlayed = 1;
    }



    public void KeypadClose()
    {
        dialogueManagerScript.bolehJalan = 1;
        animator.SetBool("KeypadOpening",false);
        isPlayed = 0;
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
