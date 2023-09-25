using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DudukScript : MonoBehaviour
{
    public GameObject ijoSeatbelt;
    public GameObject merahSeatbelt;

    //Numeric
    private int isDuduk = 0;
    private int mauDuduk = 0;
    private int isDelayed = 1;
    [SerializeField]
    private int mauBangkit = 0;
    [SerializeField]
    private int indexDuduk = 0;

    private int udahBangkit = 0;

    //GameObject
    public GameObject visualCue;
    public GameObject playerDuduk;
    public GameObject walkablePlayer;


    //Component
    public Canvas canvasConfirmation;
    public Animator animator;
    public BoxCollider2D colliderDuduk;
    public Animator anim;
    public Animator animatorKeypad;
    public Animator animatorPlayer;
    public Animator animatorShadow;
    public AudioSource audioPlayer;

    //Script
    public GameTimer gameTimerScript;
    public DialogueManager dialogueManagerScript;
    public OptionShow optionShowScript;

    [Header("buttons")]
    public GameObject button1; public GameObject button11;
    public GameObject button2; public GameObject button12;
    public GameObject button3; public GameObject button13;
    public GameObject button4; public GameObject button14;
    public GameObject button5; public GameObject button15;
    public GameObject button6; public GameObject button16;
    public GameObject button7; public GameObject button17;
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;



    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.F) && isDuduk == 0 && mauDuduk == 1 && isDelayed == 1) 
        {
            dialogueManagerScript.bolehJalan = 0;
            canvasConfirmation.gameObject.SetActive(true);
            animatorPlayer.SetBool("isWalking", false);
            animatorPlayer.SetBool("isSprinting", false);
            animatorShadow.SetBool("isWalking", false);
            animatorShadow.SetBool("isSprinting", false);
            audioPlayer.Stop();
        }
        //else if(Input.GetKey(KeyCode.E) && isDuduk == 1 && mauDuduk == 0 && isDelayed == 1 && mauBangkit == 1)
        
        if(gameTimerScript.startingTimeSecond == 329 && udahBangkit == 0)
        {
            FunctionBangkitDuduk();
            udahBangkit = 1;
        }


        if(gameTimerScript.startingTimeSecond == 361)
        {
            YesDuduk();
        }else if(gameTimerScript.startingTimeSecond == 130)
        {
            indexDuduk = 2;
            YesDuduk();
        }

    }


    private void FunctionBangkitDuduk()
    {
            StartCoroutine(BangkitDuduk());
            isDuduk = 0;
            Debug.Log("E bangkit");
            animator.SetBool("LoadingHitam", true);
            StartCoroutine(AnimatorPlay());
            StartCoroutine(Delayed());
    }

    private IEnumerator MauDuduk()
    {
        //First part
        yield return new WaitForSeconds(0.25f);
        playerDuduk.SetActive(true);
        walkablePlayer.SetActive(false);
        walkablePlayer.transform.position = new Vector3(0.1f, -1.33f, 0f);

        //Second part
        yield return new WaitForSeconds(30f);
        mauBangkit = 1;
    }

    private IEnumerator BangkitDuduk()
    {
        yield return new WaitForSeconds(0.25f);
        playerDuduk.SetActive(false);
        walkablePlayer.SetActive(true);

    }

    private IEnumerator AnimatorPlay()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("LoadingHitam", false);
    }


    private IEnumerator Delayed()
    {
        isDelayed = 0;
        yield return new WaitForSeconds(2f);
        isDelayed = 1;
    }

    public void YesDuduk() //button
    {
        StartCoroutine(MauDuduk());
        anim.SetBool("DiaOpen", false);
        animatorKeypad.SetBool("KeypadOpening", false);
        dialogueManagerScript.bolehJalan = 1;
        dialogueManagerScript.MasukDialogue = 0;
        dialogueManagerScript.buttonTouched = 0;
        optionShowScript.OptionMuncul = 0;
        dialogueManagerScript.countOptionCheck = 0;
        

        if (indexDuduk < 2)
        {
            indexDuduk++;
        }else if(indexDuduk == 2)
        {
            indexDuduk = 2;
        }

        if(gameTimerScript.startingTimeSecond == 330)
        {
            indexDuduk = 2;
        }

        isDuduk = 1;
        Debug.Log("E duduk");
        animator.SetBool("LoadingHitam", true);

        StartCoroutine(AnimatorPlay());
        StartCoroutine(Delayed());

        canvasConfirmation.gameObject.SetActive(false);

        if(indexDuduk == 1)
        {
            gameTimerScript.startingTimeSecond = 360;
        }else if(indexDuduk == 2)
        {
            gameTimerScript.startingTimeSecond = 128;
            colliderDuduk.enabled = false;
        }

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);
        button7.SetActive(false);
        button8.SetActive(false);
        button9.SetActive(false);
        button10.SetActive(false);
        button11.SetActive(false);
        button12.SetActive(false);
        button13.SetActive(false);
        button14.SetActive(false);
        button15.SetActive(false);
        button16.SetActive(false);
        button17.SetActive(false);
        ijoSeatbelt.SetActive(false);
        merahSeatbelt.SetActive(false);

    } //tutup YesDuduk

    public void NoDuduk()
    {
        canvasConfirmation.gameObject.SetActive(false);
        dialogueManagerScript.bolehJalan = 1;
    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualCue.SetActive(true);
            mauDuduk = 1;
        }//closeif
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualCue.SetActive(false);
            mauDuduk = 0;
        }//closeif


    }

}
