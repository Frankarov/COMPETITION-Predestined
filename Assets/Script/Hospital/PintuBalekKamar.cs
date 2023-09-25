using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuBalekKamar : MonoBehaviour
{

    private int masukTrigger = 0;
    public GameObject visualCue;
    public DialogueManager dialogueManagerScript;
    public Animator animatorLoadingHitam;

    public GameObject player;
    public int xnya;
    public PlayerCollide playercollideScript;

    public Canvas canvasConfirmation;
    public Animator animatorPlayer;
    public Animator animatorShadow;

    public AudioSource audioPintu;
    public AudioSource audioPlayerBug;

    private void Update()
    {
        if(Input.GetKey(KeyCode.F) && masukTrigger == 1)
        {
            canvasConfirmation.gameObject.SetActive(true);
            dialogueManagerScript.bolehJalan = 0;
            animatorPlayer.SetBool("isWalking", false);
            animatorPlayer.SetBool("isSprinting", false);
            animatorShadow.SetBool("isWalking", false);
            animatorShadow.SetBool("isSprinting", false);
            audioPlayerBug.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                masukTrigger = 1;
                visualCue.SetActive(true);
            }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                masukTrigger = 0;
                visualCue.SetActive(false);
            }
        
    }

    public void ButtonYes()
    {
        dialogueManagerScript.bolehJalan = 0;
        StartCoroutine(Transport());
        StartCoroutine(LoadingHitamTrue());
        StartCoroutine(LoadingHitamFalse());
        canvasConfirmation.gameObject.SetActive(false);
        playercollideScript.tagIndicator = 0;

    }

    public void ButtonNo()
    {
        canvasConfirmation.gameObject.SetActive(false);
        dialogueManagerScript.bolehJalan = 1;
    }

    private IEnumerator Transport()
    {
        yield return new WaitForSeconds(2);
        audioPintu.Play();
        player.transform.position = new Vector3(xnya, 0.15f, 0);
    }

    private IEnumerator LoadingHitamTrue()
    {
        yield return new WaitForSeconds(1.1f);
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(0.8f);
    }

    private IEnumerator LoadingHitamFalse()
    {
        yield return new WaitForSeconds(1.5f);
        animatorLoadingHitam.SetBool("LoadingHitam", false);
        yield return new WaitForSeconds(1f);
        dialogueManagerScript.bolehJalan = 1;

    }

}
