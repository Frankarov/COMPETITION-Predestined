using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTransport : MonoBehaviour
{

    public GameObject player;
    public Animator animatorLoadingHitam;
    public BoxCollider2D colliderKiri;
    public BoxCollider2D colliderKanan;

    public void TransportPlayerKiri()
    {
        StartCoroutine(transportKiri());
    }

    public void TransportPlayerKanan()
    {
        StartCoroutine(transportKanan());
    }

    IEnumerator transportKiri()
    {
        colliderKiri.enabled = false;
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(-32f, -1.33f, 0f);
        yield return new WaitForSeconds(1);
        animatorLoadingHitam.SetBool("LoadingHitam", false);
        colliderKiri.enabled = true;
    }
    IEnumerator transportKanan()
    {
        colliderKanan.enabled = false;
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(18f, -1.33f, 0f);
        yield return new WaitForSeconds(1);
        animatorLoadingHitam.SetBool("LoadingHitam", false);
        colliderKanan.enabled = true;
    }

}
