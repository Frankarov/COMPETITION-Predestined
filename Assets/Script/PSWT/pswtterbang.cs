using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pswtterbang : MonoBehaviour
{

    public Animator animatorLoading;
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(Gagak());
    }


    private IEnumerator Gagak()
    {
        animatorLoading.SetBool("LoadingHitam", false);
        audioSource.Play();

        float startVolume = audioSource.volume;
        float targetVolume = 0.1f;
        float duration = 5.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        audioSource.volume = targetVolume; 

        // Rest of your code
        yield return new WaitForSeconds(1);
        animatorLoading.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }


}
