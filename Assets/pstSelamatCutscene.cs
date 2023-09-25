using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pstSelamatCutscene : MonoBehaviour
{

    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(Gagak());
    }

    private IEnumerator Gagak()
    {
        audioSource.Play();


        float startVolume = audioSource.volume;
        float targetVolume = 0.1f;
        float duration = 7.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;


        // Rest of your code

        SceneManager.LoadScene("Hospital");
    }
}
