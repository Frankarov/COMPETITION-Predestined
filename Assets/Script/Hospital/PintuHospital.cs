using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PintuHospital : MonoBehaviour
{
    private int masukTrigger;
    public int xnya;
    public GameObject player;
    public Canvas canvasConfirmation;
    public BoxCollider2D colliderKeluarKamar;
    public DialogueManager dialogueManagerScript;


    public Animator animatorLoadingHitam;
    public PlayableDirector cutsceneKameraHall;
    public PlayerCollide playercollideScript;
    public Animator animatorPlayer;
    public Animator animatorShadow;

    public AudioSource audioPintu;
    public AudioSource audioPlayerBug;


    private void Update()
    {
        if (masukTrigger == 1)
        {
            canvasConfirmation.gameObject.SetActive(true);
            masukTrigger = 0;
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masukTrigger = 0;
        }
    }

    public void NoKeluar()
    {
        canvasConfirmation.gameObject.SetActive(false);
        masukTrigger = 0;
        dialogueManagerScript.bolehJalan = 1;
        
    }

    public void YesKeluar()//button
    {
        dialogueManagerScript.bolehJalan = 0;
        StartCoroutine(Transport());
        StartCoroutine(LoadingHitamTrue());
        StartCoroutine(LoadingHitamFalse());
        canvasConfirmation.gameObject.SetActive(false);
        colliderKeluarKamar.enabled = false;
        playercollideScript.tagIndicator = 0;
    }

    private IEnumerator Transport()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = new Vector3(xnya, 0.15f, 0);
        audioPintu.Play();
    }

    private IEnumerator LoadingHitamTrue()
    {
        yield return new WaitForSeconds(1.1f);
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(0.8f);
        cutsceneKameraHall.Play();
    }

    private IEnumerator LoadingHitamFalse()
    {
        yield return new WaitForSeconds(1.5f);
        animatorLoadingHitam.SetBool("LoadingHitam", false);
        yield return new WaitForSeconds(6f);
        dialogueManagerScript.bolehJalan = 1;

    }

}
