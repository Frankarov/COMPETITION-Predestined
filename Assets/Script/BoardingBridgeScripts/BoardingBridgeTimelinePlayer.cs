using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BoardingBridgeTimelinePlayer : MonoBehaviour
{

    public PlayableDirector timelinePlayer;
    public Animator animatorLoadingHitam;

    public void PlayTimeLine()
    {
        timelinePlayer.Play();
        PlayerPrefs.SetInt("Loop", 0);
        PlayerPrefs.SetInt("ilmuKecelakaan", 0);
        PlayerPrefs.SetInt("ilmuKamus", 0);
        PlayerPrefs.SetInt("ilmuMasker", 0);
        PlayerPrefs.SetInt("ilmuObat", 0);
        PlayerPrefs.SetInt("anakSelamat", 0);
        PlayerPrefs.SetInt("rusiaSelamat", 0);
        PlayerPrefs.SetInt("semuaSelamat", 0);
        PlayerPrefs.SetInt("sadarRusia", 0);
        StartCoroutine(ChangeScene(9));


    }

    private IEnumerator ChangeScene(int time)
    {
        yield return new WaitForSeconds(time);
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("CONTROL");
    }

}
