using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLibrary : MonoBehaviour
{

    private int masukTrigger = 0;
    public Canvas canvasLibrary;
    public ReichadKardusScript reichadKardusScriptScript;

    public Canvas canvasKamus;
    public Canvas canvasMorse;

    public GameObject visualCue;

    public AudioSource audioSourceKamus;
    public AudioSource audioSourcePaper;
    public AudioSource audioSourceButton;
    public AudioSource audioDapatIlmu;


    private void Update()
    {
        if(Input.GetKey(KeyCode.F) && masukTrigger == 1)
        {
            canvasLibrary.gameObject.SetActive(true);
            visualCue.SetActive(false);
        } 

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("PlayerKardus3"))
        {
            masukTrigger = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerKardus3"))
        {
            masukTrigger = 0;
        }
    }

    //button
    public void ButtonKamus()
    {
        canvasKamus.gameObject.SetActive(true);
        canvasLibrary.gameObject.SetActive(false);
        PlayerPrefs.SetInt("ilmuKamus", 1);
        audioSourceKamus.Play();
        audioDapatIlmu.Play();
    }

    public void ButtonMorse()
    {
        canvasMorse.gameObject.SetActive(true);
        canvasLibrary.gameObject.SetActive(false);
        audioSourcePaper.Play();
    }

    public void KamusBack()
    {
        canvasKamus.gameObject.SetActive(false);
        audioSourceButton.Play();
    }

    public void MorseBack()
    {
        canvasMorse.gameObject.SetActive(false);
        audioSourceButton.Play();
    }

    public void ButtonBack()
    {
        canvasLibrary.gameObject.SetActive(false);
        audioSourceButton.Play();
    }

}
