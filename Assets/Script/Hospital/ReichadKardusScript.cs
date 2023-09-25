using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReichadKardusScript : MonoBehaviour
{
    //Numeric
    private int isDelayed;
    private Vector3 ReichadKardusPosition;
    public int keyKardus;

    //Component
    public GameObject kardusNya;
    public Animator animator;
    public AudioSource audioKardus;

 


    //Script
    public KardusScript kardusScriptScript;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && kardusScriptScript.pakeKardus == 1)
        {
            StartCoroutine(LepasKardus());
            animator.SetBool("LoadingHitam", true);
            StartCoroutine(falselod());
            audioKardus.Play();
        }

    }

    private IEnumerator falselod()
    {
        yield return new WaitForSeconds(0.5f);
            animator.SetBool("LoadingHitam", false);
    }

    public IEnumerator LepasKardus()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("lepaskardus");
        //Camera & Position
        ReichadKardusPosition = transform.position;
        kardusNya.transform.position = new Vector3(ReichadKardusPosition.x, ReichadKardusPosition.y, 1);
        kardusScriptScript.walkablePlayer.transform.position = new Vector3(ReichadKardusPosition.x, ReichadKardusPosition.y, 1);
        kardusScriptScript.mainCamera.transform.position =  new Vector3 (ReichadKardusPosition.x, 0.45f, -10);
        //Component
        kardusScriptScript.gambarKardusNya.enabled = true;
        kardusScriptScript.colliderKardus.enabled = true;
        //GameObject
        kardusScriptScript.walkablePlayer.SetActive(true);
        kardusScriptScript.reichadKardus.SetActive(false);
        //Camera
        kardusScriptScript.kardusCamera.enabled = false;
        kardusScriptScript.mainCamera.enabled = true;
        //Condition
        kardusScriptScript.pakeKardus = 0;

    }



}
