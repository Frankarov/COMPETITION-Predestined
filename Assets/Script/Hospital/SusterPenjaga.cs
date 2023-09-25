using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusterPenjaga : MonoBehaviour
{
    //Script untuk suster lihat kebalakang dan kedepan (guard)

    //Numeric
    [SerializeField]
    private float switchInterval;
    private float timer = 0f;
    [SerializeField]
    private float switchIntervalSuara;
    private float timerSuara = 0f;

    //GameObject
    public GameObject susterLihatDepan;
    public GameObject susterLihatDinding;
    public GameObject visualCue;

    //Bool
    private bool susterLihatDepanON = true;

    //script
    public DialogueManager dialogueManagerScript;
    public TriggerSusterJaga triggerSusterJagaScript;

    //komponen
    public BoxCollider2D colliderNangkap;

    private BoxCollider2D colliderSuara;
    private AudioSource audioSource;
    private int masukTriggerSuara;

    private void Start()
    {
        susterLihatDepan.SetActive(susterLihatDepanON);
        susterLihatDinding.SetActive(!susterLihatDepanON);
        colliderSuara = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerKardus3"))
        {
            masukTriggerSuara = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerKardus3"))
        {
            masukTriggerSuara = 0;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timerSuara += Time.deltaTime;

        if (timer >= switchInterval)
        {
            if(triggerSusterJagaScript.ciduk == 0)
            {
                StartCoroutine(GantiObject());
                timer = 0f;

            }else if(triggerSusterJagaScript.ciduk == 1)
            {
                if(dialogueManagerScript.diTangkapSuster == 1)
                {
                    triggerSusterJagaScript.ciduk = 0;
                }
            }

        }

        //if(timerSuara >= switchIntervalSuara)
        //{
            
        //    timerSuara = 0f;
            if(masukTriggerSuara == 1)
            {
                audioSource.volume = 100f;
            }
            else
            {
                audioSource.volume = 0f;
            }
        //}




        if(susterLihatDepanON == true)
        {
            visualCue.SetActive(true);
        }else if(susterLihatDepanON == false)
        {
            visualCue.SetActive(false);
        }

    }

    private IEnumerator GantiObject()
    {
        if(susterLihatDepanON == false)
        {
            audioSource.Play();
        }

        yield return new WaitForSeconds(1.5f);
        if(triggerSusterJagaScript.ciduk == 0)
        {
            susterLihatDepanON = !susterLihatDepanON;
            susterLihatDepan.SetActive(susterLihatDepanON);
            susterLihatDinding.SetActive(!susterLihatDepanON);
        }

    }


}
