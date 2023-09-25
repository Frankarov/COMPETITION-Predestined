using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LagiPause : MonoBehaviour
{
    public Canvas canvasPause;
    public Canvas canvasOption;

    public void Resume()
    {
        Time.timeScale = 1f;
        canvasPause.gameObject.SetActive(false);
    }

    public void Option()
    {
        canvasOption.gameObject.SetActive(true);
    }

    public void OptionBack()
    {
        canvasOption.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BoardingBridge");
        
    }

}
