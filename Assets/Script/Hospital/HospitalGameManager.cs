using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalGameManager : MonoBehaviour
{
    public int hospitalLoopIndex = 0;
    public DialogueManager dialogueManagerScript;

    private void Start()
    {
        hospitalLoopIndex = PlayerPrefs.GetInt("Loop");
        dialogueManagerScript.bolehJalan = 0;
        StartCoroutine(BolehJalanHospitalAfterCutscene());
    }

    private IEnumerator BolehJalanHospitalAfterCutscene()
    {
        yield return new WaitForSeconds(10);
    }



}
