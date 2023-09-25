using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SusterJalanKeluar : MonoBehaviour
{
    //script
    public DialogueManager dialogueManagerScript;
    public PlayerCollide playerCollideScript;

    //Componen
    public PlayableDirector timeLineSusterKeluar;
    public SpriteRenderer suster;
    public BoxCollider2D triggerTelevisiKid;
    public BoxCollider2D triggerTelevisiKidRusia;
    public BoxCollider2D triggerTelevisiRusia;
    public BoxCollider2D triggerTelevisiReichad;
    public BoxCollider2D triggerTelevisiSemuaSelamat;
    public Animator animatorLoadingHitam;

    //GameObject
    public Canvas canvasTelevisi;
    public Canvas canvasTelevisiSemuaSelamat;
    public GameObject bubbleTV;
    public GameObject bubbleTVSelamat;
    public GameObject ngantuk;
    public GameObject mauExplore;

    public GameObject walkablePlayer;
    public GameObject sakitPlayer;

    public GameObject triggerDiaTidurLoop0;
    public AudioSource audioTV;

    //Numeric
    private int semuaSelamat;
    private int rusiaSelamat;
    private int anakSelamat;
    private int loopIndex;


    private int firstFunc = 0;
    [SerializeField]
    private int secFunc = 0;
    [SerializeField]
    private int televisi = 0;
    private int thirdFunc = 0;

    private int pilihTidakAda = 0;
    private int pilihNamaObat = 0;
    public int triggerTidurBuka = 0;

    public GameObject mataHitam;
    private void Update()
    {

        anakSelamat = PlayerPrefs.GetInt("anakSelamat");
        rusiaSelamat = PlayerPrefs.GetInt("rusiaSelamat");
        semuaSelamat = PlayerPrefs.GetInt("semuaSelamat");
        loopIndex = PlayerPrefs.GetInt("Loop");


        if (dialogueManagerScript.susterJalanKeluar == 1 && firstFunc == 0)
        {
            suster.flipX = false;
            timeLineSusterKeluar.Play();
            firstFunc = 1;
            if(pilihNamaObat == 1)
            {
                
                if(semuaSelamat == 1 && rusiaSelamat == 1 && anakSelamat == 1)
                {
                    StartCoroutine(AfterTVloopGoodEnding());
                }
                else
                {
                    StartCoroutine(AfterChatSusterLoop1());
                }
            }

            if(pilihTidakAda == 1)
            {
                if (loopIndex == 0)
                {
                    StartCoroutine(AfterChatSusterLoop0());
                }
                else if (loopIndex == 1)
                {
                    if(semuaSelamat == 1 && rusiaSelamat == 1 && anakSelamat == 1)
                    {
                        StartCoroutine(AfterTVloopGoodEnding());
                    }
                    else
                    {
                        StartCoroutine(AfterChatSusterLoop1());

                    }

                }
            }
        }

        if(dialogueManagerScript.televisiSiap == 1 && secFunc == 0)
        {
            Debug.Log("tvsiap");
            StartCoroutine(tutupTelevisi());
            StartCoroutine(LoadingHitamTrue());
            StartCoroutine(LoadingHitamFalse());
            secFunc = 1;
            
            if(loopIndex == 0)
            {
                StartCoroutine(AfterTVloop0());
            }else if(loopIndex == 1)
            {
                if(semuaSelamat == 1 && rusiaSelamat == 1 && anakSelamat == 1)
                {
                    StartCoroutine(AfterTVloopGoodEnding());
                }
                else
                {
                    StartCoroutine(AfterTVloop1());
                }
            }
        }

        if(dialogueManagerScript.susterJalanKeluar == 1 && televisi == 1 && thirdFunc == 0)
        {
            StartCoroutine(bukaTelevisi());
            StartCoroutine(LoadingHitamTrue());
            StartCoroutine(LoadingHitamFalse());
            playerCollideScript.tagIndicator = 7200;

            if (semuaSelamat == 0)
            {
                PlayerPrefs.SetInt("ilmuKecelakaan", 1);
                StartCoroutine(televisiONReichad());
            }else if(semuaSelamat == 1)
            {

                if(rusiaSelamat == 1 && anakSelamat == 1)
                {
                    StartCoroutine(televisiONSemuaSelamat());
                }else if(rusiaSelamat == 0 && anakSelamat == 0)
                {
                    PlayerPrefs.SetInt("sadarRusia", 1);
                    StartCoroutine(televisiONKidRusia());
                }else if(rusiaSelamat == 0 && anakSelamat == 1)
                {
                    PlayerPrefs.SetInt("sadarRusia", 1);
                    StartCoroutine(televisiONRusia());
                }else if(rusiaSelamat == 1 && anakSelamat == 0)
                {
                    StartCoroutine(televisiONKid());
                }
            }

            thirdFunc = 1;
        } 


        

    }

    private IEnumerator AfterChatSusterLoop1()
    {
        yield return new WaitForSeconds(1);
        mauExplore.SetActive(true);
        yield return new WaitForSeconds(2);
        mauExplore.SetActive(false);
        StartCoroutine(LoadingHitamTrue());
        yield return new WaitForSeconds(1);
        StartCoroutine(changePlayer());
        StartCoroutine(LoadingHitamTrue());
        StartCoroutine(LoadingHitamFalse());
        yield return new WaitForSeconds(1);
        triggerTidurBuka = 1;
    }

    private IEnumerator AfterChatSusterLoop0()
    {
        yield return new WaitForSeconds(2);
        triggerDiaTidurLoop0.SetActive(true);
        playerCollideScript.tagIndicator = 0;
        yield return new WaitForSeconds(0.5f);
        triggerDiaTidurLoop0.SetActive(false);
        Debug.Log("keluarchat");
        yield return new WaitForSeconds(5);
        Debug.Log("Load Hitam");
        ngantuk.SetActive(true);
        yield return new WaitForSeconds(2);
        mataHitam.SetActive(true);
        yield return new WaitForSeconds(13);
        //StartCoroutine(LoadingHitamTrue());
        //yield return new WaitForSeconds(2.5f);
        PlayerPrefs.SetInt("Loop", 1);
        SceneManager.LoadScene("Main");
    }

    private IEnumerator AfterTVloop1()
    {
        yield return new WaitForSeconds(4);
        mauExplore.SetActive(true);
        yield return new WaitForSeconds(3);
        mauExplore.SetActive(false);
        StartCoroutine(LoadingHitamTrue());
        yield return new WaitForSeconds(1);
        StartCoroutine(changePlayer());
        StartCoroutine(LoadingHitamTrue());
        StartCoroutine(LoadingHitamFalse());
        yield return new WaitForSeconds(1);
        triggerTidurBuka = 1;
    }

    private IEnumerator changePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        walkablePlayer.SetActive(true);
        sakitPlayer.SetActive(false);
    }

    private IEnumerator AfterTVloop0()
    {
        playerCollideScript.tagIndicator = 0;
        yield return new WaitForSeconds(2);
        Debug.Log("AktifkandialogBUG");
        triggerDiaTidurLoop0.SetActive(true);
        playerCollideScript.tagIndicator = 0;
        yield return new WaitForSeconds(1);
        triggerDiaTidurLoop0.SetActive(false);
        yield return new WaitForSeconds(4);
        ngantuk.SetActive(true);
        yield return new WaitForSeconds(1);
        mataHitam.SetActive(true);
        yield return new WaitForSeconds(13);
        //StartCoroutine(LoadingHitamTrue());
        //yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("Loop", 1);
        SceneManager.LoadScene("Main");

    }
    private IEnumerator AfterTVloopGoodEnding()
    {
        Debug.Log("GoodEnding");
        yield return new WaitForSeconds(2);
        bubbleTVSelamat.SetActive(true);
        yield return new WaitForSeconds(2);
        bubbleTVSelamat.SetActive(false);
        yield return new WaitForSeconds(1);
        ngantuk.SetActive(true);
        yield return new WaitForSeconds(2);
        StartCoroutine(LoadingHitamTrue());
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Ending");

    }


    #region animasitv

    private IEnumerator bukaTelevisi()
    {
        yield return new WaitForSeconds(2.5f);

        audioTV.Play();
        if(semuaSelamat == 0)
        {
            canvasTelevisi.gameObject.SetActive(true);
        }else if(semuaSelamat == 1)
        {
            canvasTelevisiSemuaSelamat.gameObject.SetActive(true);
        }



    }

    private IEnumerator tutupTelevisi()
    {
        yield return new WaitForSeconds(2f);
        if (semuaSelamat == 0)
        {
            canvasTelevisi.gameObject.SetActive(false);
        }
        else if (semuaSelamat == 1)
        {
            canvasTelevisiSemuaSelamat.gameObject.SetActive(false);
        }
    }

    private IEnumerator LoadingHitamTrue()
    {
        Debug.Log("startloadingitam");
        yield return new WaitForSeconds(1.1f);
        animatorLoadingHitam.SetBool("LoadingHitam", true);
    }

    private IEnumerator LoadingHitamFalse()
    {
        yield return new WaitForSeconds(1.5f);
        animatorLoadingHitam.SetBool("LoadingHitam", false);

    }
    #endregion

    #region televisitrigger
    private IEnumerator televisiONKid()
    {
        yield return new WaitForSeconds(3);
        triggerTelevisiKid.enabled = true;
        yield return new WaitForSeconds(1);
        triggerTelevisiKid.enabled = false;
    }

    private IEnumerator televisiONRusia()
    {
        yield return new WaitForSeconds(3);
        triggerTelevisiRusia.enabled = true;
        yield return new WaitForSeconds(1);
        triggerTelevisiRusia.enabled = false;
    }

    private IEnumerator televisiONReichad()
    {
        yield return new WaitForSeconds(3);
        triggerTelevisiReichad.enabled = true;
        yield return new WaitForSeconds(1);
        triggerTelevisiReichad.enabled = false;
    }

    private IEnumerator televisiONKidRusia()
    {
        yield return new WaitForSeconds(3);
        triggerTelevisiKidRusia.enabled = true;
        yield return new WaitForSeconds(1);
        triggerTelevisiKidRusia.enabled = false;
    }

    private IEnumerator televisiONSemuaSelamat() //yang ini nanti butuh canvas baru 
    {
        yield return new WaitForSeconds(3);
        triggerTelevisiSemuaSelamat.enabled = true;
        yield return new WaitForSeconds(1);
        triggerTelevisiSemuaSelamat.enabled = false;
    }

    #endregion
    //button 
    public void NamaObat()
    {
        pilihNamaObat = 1;
        PlayerPrefs.SetInt("ilmuObat", 1);
    }

    public void TidakAda()
    {
        pilihTidakAda = 1;
    }

    public void Televisi()
    {
        televisi = 1;
    }



}
