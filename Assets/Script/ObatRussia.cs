using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObatRussia : MonoBehaviour
{
    //Numeric
    public int dapatObat = 0;
    public GameTimer gameTimerScript;
    public DialogueManager dialogueManagerScript;
    public Animator animasiRusia;

    private int done = 0;
    private int donee = 0;
    public void DapatObat() //utk button pramugari lavatory
    {
        dapatObat = 1;
    }

    private void Update()
    {
        if(gameTimerScript.badaiIndex == 1 && done == 0)
        {
            animasiRusia.SetBool("rusiaPanik", true);
            done = 1;
        }

        if(dialogueManagerScript.russiaCured == 1 && donee == 0)
        {
            animasiRusia.SetBool("rusiaPanik", false);
            donee = 1;
        }
    }

}
