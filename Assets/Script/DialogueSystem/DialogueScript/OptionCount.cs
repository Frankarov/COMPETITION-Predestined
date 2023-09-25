using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCount : MonoBehaviour
{
    public int countOptionCheck;
    //public int buttonTouched = 0;
    public DialogueManager dialogueManagerScript;
    public void MulaiHitung()
    {
        Debug.Log("Mulai hitung");

        dialogueManagerScript.buttonTouched = 1;
    }

    private void Update()
    {
        countOptionCheck = dialogueManagerScript.countOptionCheck;
        if (dialogueManagerScript.buttonTouched == 1 && Input.GetKeyDown(KeyCode.E) && dialogueManagerScript.complete)
        {
            //Hitung();
        }
    }

    private void Hitung()
    {
        countOptionCheck++;
    }


}
