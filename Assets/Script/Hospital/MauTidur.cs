using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MauTidur : MonoBehaviour
{


    public Animator animatorLoadingHitam;
    public GameObject VisualCue;
    public Canvas canvasConfirmationTidur;
    public DialogueManager dialogueManagerScript;

    public GameObject player;
    public GameObject playerTidur;
    public BoxCollider2D ownCollider;

    private int masukTrigger = 0;
    public GameObject triggerTidurDiaLoop1;
    public GameObject triggerTidurDiaLoop0;
    public SusterJalanKeluar susterJalanKeluarScript;

    private int halang = 0;

    private int blompernah = 0;
    public Animator animatorPlayer;
    public Animator animatorShadow;

    public AudioSource audioPlayerBug;
    public GameObject mataHitam;

    private void Start()
    {
        ownCollider.enabled = false;
    }
    private void Update()
    {
        if(masukTrigger == 1 && Input.GetKey(KeyCode.F) && blompernah == 0)
        {
            canvasConfirmationTidur.gameObject.SetActive(true);
            dialogueManagerScript.bolehJalan = 0;
            animatorPlayer.SetBool("isWalking", false);
            animatorPlayer.SetBool("isSprinting", false);
            animatorShadow.SetBool("isWalking", false);
            animatorShadow.SetBool("isSprinting", false);
            audioPlayerBug.Stop();
        }

        if(susterJalanKeluarScript.triggerTidurBuka == 1 && halang == 0)
        {
            ownCollider.enabled = true;
            halang = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masukTrigger = 1;
            VisualCue.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            masukTrigger = 0;
            VisualCue.SetActive(false);
        }
    }

    public void YesTidur()
    {
        blompernah = 1;
        StartCoroutine(TidurTime());
        StartCoroutine(LoadingHitamTrue());
        StartCoroutine(LoadingHitamFalse());
        ownCollider.enabled = false;
    }

    public void NoTidur()
    {
        dialogueManagerScript.bolehJalan = 1;
        canvasConfirmationTidur.gameObject.SetActive(false);
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

    }

    public IEnumerator TidurTime()
    {
        canvasConfirmationTidur.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        player.SetActive(false);
        playerTidur.SetActive(true);
        triggerTidurDiaLoop1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        triggerTidurDiaLoop1.SetActive(false);
        mataHitam.SetActive(true);
        yield return new WaitForSeconds(11);
        //animatorLoadingHitam.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main");
    }





}
