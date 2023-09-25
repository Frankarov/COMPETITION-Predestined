using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefHospitalManager : MonoBehaviour
{

    //Game Object
    public GameObject anakSakit;
    public GameObject ibuSakit;
    public GameObject ibuNangis;
    public GameObject russiaSakit;
    public GameObject pilotSakit;
    public GameObject pramu1Sakit;
    public GameObject pramu2Sakit;

    //Numeric
    private int semuaSelamat;
    private int russiaSelamat;
    private int anakSelamat;




    private void Start()
    {

    }

    private void Update()
    {

        semuaSelamat = PlayerPrefs.GetInt("semuaSelamat");
        russiaSelamat = PlayerPrefs.GetInt("rusiaSelamat");
        anakSelamat = PlayerPrefs.GetInt("anakSelamat");

        if(semuaSelamat == 1)
        {

            pilotSakit.SetActive(true);
            pramu1Sakit.SetActive(true);
            pramu2Sakit.SetActive(true);

            if(anakSelamat == 0)
            {
                ibuNangis.SetActive(true);

            }else if(anakSelamat == 1)
            {
                ibuSakit.SetActive(true);
                anakSakit.SetActive(true);
            }

            if(russiaSelamat == 1)
            {
                russiaSakit.SetActive(true);
            }
        }//tutup if1

    }

}
