using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PAUSEMENU : MonoBehaviour
{

    public Canvas canvasPause;
    public Canvas canvasOption;
    private int Paused = 0;
    public AudioSource audioJalan;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && Paused == 0)
        {
            Debug.Log("kepause");
            Time.timeScale = 0f;
            canvasPause.gameObject.SetActive(true);
            Paused = 1;
            audioJalan.Stop();
            
            
        }else if(Input.GetKeyUp(KeyCode.Escape) && Paused == 1)
        {
            Debug.Log("Unpause");
            Time.timeScale = 1f;
            canvasPause.gameObject.SetActive(false);
            canvasOption.gameObject.SetActive(false);
            Paused = 0;
        }



    }

    


}
