using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalekKeKabin : MonoBehaviour
{
    //Script canvas
    public DialogueManager dialogueManagerScript;
    public Canvas canvasConfirmation;
    public BoxCollider2D colliderBalekKeKabin;
    public Animator animatorPlayer;
    public Animator animatorShadow;

    public AudioSource audioPintu;
    public void ButtonKick()
    {
        dialogueManagerScript.diKick = 1;
        audioPintu.Play();
        canvasConfirmation.gameObject.SetActive(false);
        colliderBalekKeKabin.enabled = false;

    }

    public void ButtonNo()
    {
        canvasConfirmation.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasConfirmation.gameObject.SetActive(true);
            animatorPlayer.SetBool("isWalking", false);
            animatorPlayer.SetBool("isSprinting", false);
            animatorShadow.SetBool("isWalking", false);
            animatorShadow.SetBool("isSprinting", false);
        }
    }


}
