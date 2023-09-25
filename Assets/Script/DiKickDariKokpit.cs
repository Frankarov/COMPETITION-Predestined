using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiKickDariKokpit : MonoBehaviour
{

    //Script
    public DialogueManager dialogueManagerScript;

    //Vector
    [SerializeField]
    private float xNya;

    //GameObject
    public GameObject player;

    //Component
    public Animator animatorLoadingHitam;
    public AudioSource audioPintu;
    private void Update()
    {
        if(dialogueManagerScript.diKick == 1)
        {
            StartCoroutine(DiKick());
            StartCoroutine(LoadingHitamTrue());
            StartCoroutine(LoadingHitamFalse());
        }
    }

    private IEnumerator DiKick()
    {
        yield return new WaitForSeconds(2f);
        player.transform.position = new Vector3(xNya, -1.03f, 0);
        audioPintu.Play();
        dialogueManagerScript.diKick = 0;
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
