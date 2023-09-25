using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucingTriggerScript : MonoBehaviour
{

    public BoxCollider2D colliderBefore;
    public BoxCollider2D colliderAfter;

    private int loopIndex;
    private int anakSelamat;
    private int semuaSelamat;
    private int rusiaSelamat;
    private int Done = 0;

    public GameObject kucingParent;

    private void Start()
    {
        loopIndex = PlayerPrefs.GetInt("Loop");
        anakSelamat = PlayerPrefs.GetInt("anakSelamat");
        semuaSelamat = PlayerPrefs.GetInt("semuaSelamat");
        rusiaSelamat = PlayerPrefs.GetInt("rusiaSelamat");
    }

    private void Update()
    {

        if(anakSelamat == 1 && semuaSelamat == 1 && rusiaSelamat == 1)
        {
            kucingParent.SetActive(false);
        }
        else
        {
            if (loopIndex == 0 && Done == 0)
            {
                colliderBefore.enabled = true;
                colliderAfter.enabled = false;
                Done = 1;
            }else if(loopIndex == 1 && Done == 0)
            {
                colliderBefore.enabled = false;
                colliderAfter.enabled = true;
                Done = 1;
            }
        }

    }



}
