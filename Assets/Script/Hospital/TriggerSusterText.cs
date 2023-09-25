using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSusterText : MonoBehaviour
{
    private BoxCollider2D ownCollider;
    public GameObject bubble;
    private int masuk = 0;
    private int firstFunc = 0;
    private void Start()
    {
        ownCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(masuk == 1 && firstFunc == 0)
        {
            StartCoroutine(startmuncul());
            firstFunc = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("PlayerKardus3")){
            masuk = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerKardus3"))
        {
            masuk = 0;
        }
    }

    private IEnumerator startmuncul()
    {
        bubble.SetActive(true);
        yield return new WaitForSeconds(3);
        bubble.SetActive(false);

    }

}
