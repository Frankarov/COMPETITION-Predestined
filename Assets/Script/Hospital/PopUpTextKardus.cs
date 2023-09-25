using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextKardus : MonoBehaviour
{


    public GameObject textNya;
    private int masukTrig = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && masukTrig == 0)
        {
            masukTrig = 1;
            StartCoroutine(Jalan());
        }
    }

    private IEnumerator Jalan()
    {
        textNya.SetActive(true);
        yield return new WaitForSeconds(3);
        textNya.SetActive(false);
    }


}
