using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletScript : MonoBehaviour
{

    //Numeric
    public int masukToilet = 0;
    private int masukTriggerToilet = 0;

    //GameObject
    public Canvas canvasConfirmation;
    public GameObject visualCue;

    //Component
    public Animator animatorLoadingHitam;
    public BoxCollider2D boxColliderToilet;
    public Animator animatorPlayer;
    public Animator animatorShadow;

    //Script
    public DialogueManager dialogueManagerScript;
    public AudioSource audioPlayerBug;
    public AudioSource audioToilet;


    public void Update()
    {
        if(Input.GetKey(KeyCode.F) && masukTriggerToilet == 1)
        {
            canvasConfirmation.gameObject.SetActive(true);
            dialogueManagerScript.bolehJalan = 0;
            animatorPlayer.SetBool("isWalking", false);
            animatorPlayer.SetBool("isSprinting", false);
            animatorShadow.SetBool("isWalking", false);
            animatorShadow.SetBool("isSprinting", false);
            audioPlayerBug.Stop();
        }

        if(masukToilet == 1)
        {
            boxColliderToilet.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            masukTriggerToilet = 1;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            masukTriggerToilet = 0;
            visualCue.SetActive(false);
        }
    }

    public void YesToilet() //button
    {
        StartCoroutine(BolehJalan());
        StartCoroutine(LoadingHitamTrue());
        StartCoroutine(LoadingHitamFalse());
        audioToilet.Play();
        canvasConfirmation.enabled = false;

        masukToilet = 1;
    }

    public void NoToilet() //button
    {
        canvasConfirmation.gameObject.SetActive(false);
        dialogueManagerScript.bolehJalan = 1;
    }

    private IEnumerator BolehJalan()
    {
        dialogueManagerScript.bolehJalan = 0;
        yield return new WaitForSeconds(1);
        dialogueManagerScript.bolehJalan = 1;
    }

    private IEnumerator LoadingHitamTrue()
    {
        yield return new WaitForSeconds(0.5f);
        animatorLoadingHitam.SetBool("LoadingHitam", true);
    }

    private IEnumerator LoadingHitamFalse()
    {
        yield return new WaitForSeconds(1.5f);
        animatorLoadingHitam.SetBool("LoadingHitam", false);
    }
}
