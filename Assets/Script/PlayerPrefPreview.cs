using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefPreview : MonoBehaviour
{
    //SCRIPT HANYA UNTUK LIHAT DETAIL CONDITION
    [SerializeField]
    private int loopIndex;
    [SerializeField]
    private int ilmuKecelakaan;
    [SerializeField]
    private int anakSelamat;
    [SerializeField]
    private int rusiaSelamat;
    [SerializeField]
    private int semuaSelamat;
    [SerializeField]
    private int ilmuKamus;
    [SerializeField]
    private int ilmuObat;
    [SerializeField]
    private int ilmuMasker;
    [SerializeField]
    private int sadarRusia;

    [Header("Ganti")]
    [SerializeField]
    private int XloopIndex;
    [SerializeField]
    private int XilmuKecelakaan;
    [SerializeField]
    private int XanakSelamat;
    [SerializeField]
    private int XrusiaSelamat;
    [SerializeField]
    private int XsemuaSelamat;
    [SerializeField]
    private int XilmuKamus;
    [SerializeField]
    private int XilmuObat;
    [SerializeField]
    private int XilmuMasker;
    [SerializeField]
    private int XsadarRusia;

    [SerializeField]
    private int mauEdit = 0;

    private void Update()
    {
        loopIndex = PlayerPrefs.GetInt("Loop");
        ilmuKecelakaan = PlayerPrefs.GetInt("ilmuKecelakaan");
        anakSelamat = PlayerPrefs.GetInt("anakSelamat");
        rusiaSelamat = PlayerPrefs.GetInt("rusiaSelamat");
        semuaSelamat = PlayerPrefs.GetInt("semuaSelamat");
        ilmuKamus = PlayerPrefs.GetInt("ilmuKamus");
        ilmuObat = PlayerPrefs.GetInt("ilmuObat");
        ilmuMasker = PlayerPrefs.GetInt("ilmuMasker");
        sadarRusia = PlayerPrefs.GetInt("sadarRusia");

        if(mauEdit == 1)
        {
            PlayerPrefs.SetInt("Loop", XloopIndex);
            PlayerPrefs.SetInt("ilmuKecelakaan",XilmuKecelakaan);
            PlayerPrefs.SetInt("anakSelamat", XanakSelamat);
            PlayerPrefs.SetInt("rusiaSelamat", XrusiaSelamat);
            PlayerPrefs.SetInt("semuaSelamat", XsemuaSelamat);
            PlayerPrefs.SetInt("ilmuKamus", XilmuKamus);
            PlayerPrefs.SetInt("ilmuObat", XilmuObat);
            PlayerPrefs.SetInt("ilmuMasker", XilmuMasker);
            PlayerPrefs.SetInt("sadarRusia", XsadarRusia);
        }


    }





}
