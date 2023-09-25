using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunwayKucing : MonoBehaviour
{
    public AudioSource audioSource; //api
    public AudioSource audioKucing;
    public AudioSource audioSiren;


    private void Start()
    {
        StartCoroutine(Gagak());
    }


    private IEnumerator Gagak()
    {
        audioSource.Play();
        audioKucing.Play();
        audioSiren.Play();

        float startVolume = audioSource.volume;
        float targetVolume = 0.1f;
        float duration = 5.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);
            audioKucing.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);
            audioSiren.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
        audioKucing.volume = targetVolume;
        audioSiren.volume = targetVolume;

        // Rest of your code
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Hospital");
    }

}
