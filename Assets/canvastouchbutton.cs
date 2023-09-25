using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvastouchbutton : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void touchSuara()
    {
        audioSource.Play();
    }
}
