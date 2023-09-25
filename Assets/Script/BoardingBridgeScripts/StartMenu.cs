using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Canvas canvasOption;
    public Animator animatorLoadingHitam;
    public void Option()
    {
        canvasOption.gameObject.SetActive(true);
    }

    public void OptionBack()
    {
        canvasOption.gameObject.SetActive(false);
    }

    public void Credit()
    {
        animatorLoadingHitam.SetBool("LoadingHitam", true);
        SceneManager.LoadScene("Credit");
    }

    public void Quit()
    {
        Application.Quit();
    }



}
