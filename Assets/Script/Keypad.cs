using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{

    //Numeric
    string Passcode = "072923";
    string Number = null;
    private int NumberIndex = 0;
    private int Jeda;

    //GameObject
    public GameObject player;

    //Script
    public KeypadTrigger keypadTriggerScript;

    //Text
    public Text uiText = null;

    //Component
    public Animator animator;
    public Animator animatorLoadingHitam;

    public AudioSource audioPintu;


    public void CodeFunction(string TheNumber)
    {
        if(Jeda == 0)
        {
            NumberIndex++;
            Number = Number + TheNumber;
            uiText.text = Number;
        }

    }

    public void Enter()
    {
        if(Number == Passcode)
        {
            Debug.Log("Betul pass");
            uiText.text = "Betul";
            StartCoroutine(DeleteDelay());
            StartCoroutine(PassBetul());
            StartCoroutine(LoadingHitamTrue());
            StartCoroutine(LoadingHitamFalse());

            keypadTriggerScript.KeypadClose();
        }else if(Number != Passcode){
            uiText.text = "SALAH";
            StartCoroutine(DeleteDelay());
            Debug.Log("Salah pass");
        }
    }

    public void Delete()
    {
        NumberIndex++;
        Number = null;
        uiText.text = Number;
    }

    private IEnumerator DeleteDelay()
    {
        Jeda = 1;
        yield return new WaitForSeconds(1);
        Delete();
        Jeda = 0;
    }

    private IEnumerator PassBetul()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("TransportKeKokpit");
        audioPintu.Play();
        player.transform.position = new Vector3(61.61f, -1.03f, 0f);
    }

    private IEnumerator LoadingHitamTrue()
    {
        yield return new WaitForSeconds(1.1f);
        animatorLoadingHitam.SetBool("LoadingHitam", true);
    }

    private IEnumerator LoadingHitamFalse()
    {
        yield return new WaitForSeconds(1.5f);
        animatorLoadingHitam.SetBool("LoadingHitam", false);
    }


}
