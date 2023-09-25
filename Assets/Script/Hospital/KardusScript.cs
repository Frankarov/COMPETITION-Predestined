using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KardusScript : MonoBehaviour
{
    //Numeric
    public int pakeKardus = 0;
    private int mauKardus = 0;
    private int isDelayed;

    //Component
    public BoxCollider2D colliderKardus;
    public Animator animator;
    public SpriteRenderer gambarKardusNya;
    public GameObject walkablePlayer;

    //GameObject
    public GameObject reichadKardus;

    //Camera
    public Camera mainCamera;
    public Camera kardusCamera;

    public AudioSource audioKardus;




    private void Start()
    {
        //Enable main camera karena tah kenapa kardusCameranya diutamakan
        kardusCamera.enabled = false;
        mainCamera.enabled = true;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && mauKardus == 1 && pakeKardus == 0)
        {
            Debug.Log("Pakekardus");
            StartCoroutine(PakeKardus());
            animator.SetBool("LoadingHitam", true);
            StartCoroutine(AnimatorPlay());
            StartCoroutine(Delayed());
            mauKardus = 0;
        }

    }

    private IEnumerator AnimatorPlay()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("setfalsetoloadinghitamX");
        animator.SetBool("LoadingHitam", false);
    }

    private  IEnumerator PakeKardus()
    {
        yield return new WaitForSeconds(1f);
        //Numeric
        pakeKardus = 1;
        //Component
        audioKardus.Play();
        colliderKardus.enabled = false;
        gambarKardusNya.enabled = false;
        //GameObject
        reichadKardus.SetActive(true);
        walkablePlayer.SetActive(false);
        //Camera
        kardusCamera.enabled = true;
        mainCamera.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mauKardus = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mauKardus = 0;
        }
    }

    private IEnumerator Delayed()
    {
        //Dipake untuk cegah spam E/F (interaction pada kardus)
        isDelayed = 0;
        yield return new WaitForSeconds(2f);
        isDelayed = 1;
    }

}
