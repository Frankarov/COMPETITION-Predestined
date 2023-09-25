using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartKabinDialogue : MonoBehaviour
{

    private int loopIndex;
    private int udahCukup = 0;
    private int waktunyaKeToilet = 0;

    public Animator animatorLoadingHitam;

    public GameObject playerDuduk;
    public GameObject playerWalkable;

    public DialogueManager dialogueManagerScript;
    public DialogueTriggerAutoNoTPNew dialogueTriggerAutoNoTPNewScript;
    public DialogueTriggerAutoNoTPNew dialogueTriggerAutoNoTPNewScript2;
    public DialogueTriggerAutoNoTPNew dialogueTriggerAutoNoTPNewScript3;


    private void Start()
    {
        loopIndex = PlayerPrefs.GetInt("Loop");

        dialogueManagerScript.bolehJalan = 0;

        if (loopIndex == 0)
        {
            StartCoroutine(StartDialogue());
        }
        else if (loopIndex == 1)
        {
            StartCoroutine(StartDialogue2());
        }
    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(5);
        dialogueTriggerAutoNoTPNewScript.Packet();
    }

    private IEnumerator StartDialogue2()
    {
        yield return new WaitForSeconds(5);
        dialogueTriggerAutoNoTPNewScript2.Packet();
    }

    private void Update()
    {
        if (dialogueManagerScript.bolehJalan == 1 && udahCukup == 0)
        {
            waktunyaKeToilet = 1;
            udahCukup = 1;
        }

        if (waktunyaKeToilet == 1)
        {
            StartCoroutine(Swap());
            StartCoroutine(LoadingHitamTrue());
            StartCoroutine(LoadingHitamFalse());
            waktunyaKeToilet = 2;
        }
    }

    public IEnumerator Swap()
    {
        yield return new WaitForSeconds(2f);
        playerDuduk.SetActive(false);
        playerWalkable.SetActive(true);
    }

    private IEnumerator LoadingHitamTrue()
    {
        yield return new WaitForSeconds(1.1f);
        animatorLoadingHitam.SetBool("LoadingHitam", true);
    }

    private IEnumerator LoadingHitamFalse()
    {
        yield return new WaitForSeconds(1.5f);
        animatorLoadingHitam.SetBool("LoadingHitam", false);

    }
}
