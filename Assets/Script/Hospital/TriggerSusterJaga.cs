using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSusterJaga : MonoBehaviour
{

    public int dapatKau = 0;
    public int diaGerak = 0;
    public int ciduk = 0;
    public KardusMovement kardusMovementScript;
    private BoxCollider2D boxCollider2D;
    public DialogueManager dialogueManagerScript;
    public BoxCollider2D colliderPintu;

    public AudioSource audioSusterMarah;
    private int playSound = 0;
    

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("PlayerKardus2"))
        {
            dapatKau = 1;
        }

        if (collision.CompareTag("PlayerKardus3"))
        {
            dapatKau = 1;
        }

        if (collision.CompareTag("Player"))
        {
            ciduk = 1;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }



    private void Update()
    {
        if(dapatKau == 1 && diaGerak == 1)
        {
            ciduk = 1;
            StartCoroutine(DisableCol());
        }

        if(ciduk == 1)
        {
            if(playSound == 0)
            {
                audioSusterMarah.Play();
                playSound = 1;
            }
            StartCoroutine(DisableColIfPlayer());
        }
    }

    private IEnumerator DisableColIfPlayer()
    {
        yield return new WaitForSeconds(2);
        dialogueManagerScript.diTangkapSuster = 1;
        yield return new WaitForSeconds(0.5f);
        boxCollider2D.enabled = false;
        colliderPintu.enabled = false;
    }

    private IEnumerator DisableCol()
    {
        yield return new WaitForSeconds(2);
        dialogueManagerScript.diTangkapSuster = 1;
        yield return new WaitForSeconds(0.5f);
        boxCollider2D.enabled = false;
        colliderPintu.enabled = false;
    }


}
