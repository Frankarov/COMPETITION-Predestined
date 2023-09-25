using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameTimer : MonoBehaviour
{
    //Numeric
    [SerializeField]
    private int loopIndex;
    private float decrement = 0;
    public int currentTimeMinute = 0;
    public float currentTimeSecond = 0f;
    public float startingTimeSecond = 480f;
    public int badaiIndex = 0;

    private int semuaSelamat;
    private int rusiaSelamat;
    private int anakSelamat;

    public AudioSource sfxBadai;
    public AudioSource sfxPetir;
    public AudioSource sfxPetirCut;
    public AudioSource sfxKabin;
    public AudioSource sfxKecelakaan;

    //Inspector Text
    [SerializeField] Text countDownTextMinute;
    [SerializeField] Text countDownTextSecond;

    private void Start()
    {
        currentTimeMinute = (int)startingTimeSecond / 60;
        currentTimeSecond = startingTimeSecond % 60;

        countDownTextMinute.text = currentTimeMinute.ToString("0");
        countDownTextSecond.text = currentTimeSecond.ToString("0");
        loopIndex = PlayerPrefs.GetInt("Loop");
    }

    private void Update()
    {
        anakSelamat = PlayerPrefs.GetInt("anakSelamat");
        semuaSelamat = PlayerPrefs.GetInt("semuaSelamat");
        rusiaSelamat = PlayerPrefs.GetInt("rusiaSelamat");


        decrement += Time.deltaTime;

        if(decrement > 1 )
        {
            decrement = 1;

            startingTimeSecond -= decrement;

            currentTimeMinute = (int)startingTimeSecond / 60;
            currentTimeSecond = startingTimeSecond % 60;

            decrement = 0;
        }

        countDownTextMinute.text = currentTimeMinute.ToString("0");
        countDownTextSecond.text = currentTimeSecond.ToString("0");

        if (currentTimeMinute<=0)
        {
            currentTimeMinute = 0;
        }

        if (currentTimeSecond <= 0)
        {
            currentTimeSecond = 0;
        }

        if(currentTimeMinute==0 && currentTimeSecond == 1)
        {
            loopIndex = PlayerPrefs.GetInt("Loop");
        }

        if(startingTimeSecond == 123)
        {
            sfxKecelakaan.Play();
        }

        if(startingTimeSecond == 120)
        {
            if(semuaSelamat == 0)
            {
                SceneManager.LoadScene("RunwayCutscene");
            }else if(semuaSelamat == 1)
            {
                SceneManager.LoadScene("SelamatCutscene");
            }

        }



        if(startingTimeSecond == 360)
        {
            badaiIndex = 1;
            
        }

        if(startingTimeSecond <= 363 && startingTimeSecond >= 328)
        {
            sfxKabin.volume = 0.3f;

            if (!sfxBadai.isPlaying)
            {
                sfxBadai.Play();
            }

        }
        else
        {
            sfxBadai.Stop();
            sfxKabin.volume = 0.5f;
        }

        if(startingTimeSecond ==  355 || startingTimeSecond == 346 || startingTimeSecond == 340)
        {
            sfxPetir.Play();
        }
        if(startingTimeSecond == 355 || startingTimeSecond == 340)
        {
            sfxPetirCut.Play();
        }

    } //close if update


}
