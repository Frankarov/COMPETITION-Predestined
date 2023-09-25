using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOMCRYTrigger : MonoBehaviour
{

    private int anakSelamat;
    private int semuaSelamat;

    private BoxCollider2D ownCollider;
    private int halang = 0;
    public AudioSource audioNangis;

    private void Start()
    {
        ownCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        anakSelamat = PlayerPrefs.GetInt("anakSelamat");
        semuaSelamat = PlayerPrefs.GetInt("semuaSelamat");

        if(anakSelamat == 0  && semuaSelamat == 1 && halang == 0)
        {
            ownCollider.enabled = true;
            halang = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!audioNangis.isPlaying)
            {
                audioNangis.Play();

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioNangis.Stop();
        }
    }

}
