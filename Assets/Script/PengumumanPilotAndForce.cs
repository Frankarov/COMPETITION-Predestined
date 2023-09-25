using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PengumumanPilotAndForce : MonoBehaviour
{

    //Script
    public DialogueManager dialogueManagerScript;
    public GameTimer gameTimerScript;
    public PlayerCollide playerCollideScript;

    //Komponen
    //public BoxCollider2D colliderPengumuman1;
    //public BoxCollider2D colliderPengumuman2;
    //public BoxCollider2D colliderPengumuman3;
    public GameObject pengumuman1;
    public GameObject pengumuman2;
    public GameObject pengumuman3;


    public GameObject ijo;
    public GameObject merah;


    //Numeric
    private int semuaSelamat;

    public AudioSource sfxSeatbelt;

    private void Start()
    {
        sfxSeatbelt.Play();
        StartCoroutine(ijotokstart());
    }

    private void Update()
    {

        semuaSelamat = PlayerPrefs.GetInt("semuaSelamat");
        


        if(gameTimerScript.startingTimeSecond < 375 && gameTimerScript.startingTimeSecond > 361 && dialogueManagerScript.MasukDialogue == 0)
        {
            playerCollideScript.tagIndicator = 0;
            pengumuman1.SetActive(true);
            pengumuman2.SetActive(false);
            pengumuman3.SetActive(false);

            //colliderPengumuman1.enabled = true;
            //colliderPengumuman2.enabled = false;
            //colliderPengumuman3.enabled = false;
        }
        else if(gameTimerScript.startingTimeSecond < 140 && gameTimerScript.startingTimeSecond > 130 && dialogueManagerScript.MasukDialogue == 0)
        {

            if (semuaSelamat == 0)
            {
                playerCollideScript.tagIndicator = 0;
                pengumuman1.SetActive(false);
                pengumuman2.SetActive(true);
                pengumuman3.SetActive(false);
            }
            else if(semuaSelamat == 1)
            {
                playerCollideScript.tagIndicator = 0;
                pengumuman1.SetActive(false);
                pengumuman2.SetActive(false);
                pengumuman3.SetActive(true);
            }

        }

        if(gameTimerScript.startingTimeSecond == 374)
        {
            sfxSeatbelt.Play();
            StartCoroutine(merahtok());
        }

        if(gameTimerScript.startingTimeSecond == 141)
        {
            sfxSeatbelt.Play();
            StartCoroutine(merahtok());
        }

        if(gameTimerScript.startingTimeSecond == 327)
        {
            sfxSeatbelt.Play();
            StartCoroutine(ijotok());
        }


    }//void update

    private IEnumerator ijotokstart()
    {
        ijo.SetActive(true);
        yield return new WaitForSeconds(2);
        ijo.SetActive(false);
        yield return new WaitForSeconds(2);
        ijo.SetActive(true);
        yield return new WaitForSeconds(2);
        ijo.SetActive(false);
    }

    private IEnumerator ijotok()
    {
        ijo.SetActive(true);
        yield return new WaitForSeconds(2);
        ijo.SetActive(false);
        yield return new WaitForSeconds(1);
        ijo.SetActive(true);
        yield return new WaitForSeconds(2);
        ijo.SetActive(false);
    }

    private IEnumerator merahtok()
    {
        merah.SetActive(true);
        yield return new WaitForSeconds(2);
        merah.SetActive(false);
        yield return new WaitForSeconds(1);
        merah.SetActive(true);
        yield return new WaitForSeconds(2);
        merah.SetActive(false);
    }

}
