using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefManager : MonoBehaviour
{
    private string currentSceneName;
    public AudioSource audioDapatIlmu;
    private void Start()
    {
        //Untuk mulai fresh di pesawat

    }

    //Untuk button-button
    public void SetIlmuKecelakaan()
    {
        audioDapatIlmu.Play();
        PlayerPrefs.SetInt("ilmuKecelakaan", 1);
    }

    public void SetAnakSelamat()
    {
        audioDapatIlmu.Play();
        PlayerPrefs.SetInt("anakSelamat", 1);
    }

    public void SetRussiaSelamat()
    {
        audioDapatIlmu.Play();
        PlayerPrefs.SetInt("rusiaSelamat", 1);
    }

    public void SetSemuaSelamat()
    {
        audioDapatIlmu.Play();
        PlayerPrefs.SetInt("semuaSelamat", 1);
    }

    public void SetIlmuMasker()
    {
        audioDapatIlmu.Play();
        PlayerPrefs.SetInt("ilmuMasker", 1);
    }

}
