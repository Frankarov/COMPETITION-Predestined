using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetahuanSuster : MonoBehaviour
{

    public BoxCollider2D colliderSusterJaga;
    public DialogueManager dialogueManagerScript;
    public GameObject player;
    public TriggerSusterJaga triggerSusterJagaScript;
    private int firstFunc = 0;

    public GameObject reichadKardus;
    public GameObject walkablePlayer;
    public Camera main;
    public Camera kardus;

    public DialogueTriggerAutoNoTP dialogueTriggerAutoNoTPScript;

    private void Update()
    {
        if(dialogueManagerScript.diTangkapSuster == 1 && firstFunc == 0)
        {
            
            reichadKardus.SetActive(false);
            walkablePlayer.SetActive(true);
            main.enabled = true;
            kardus.enabled = false;

            player.transform.position = new Vector3(-14.3f, 0.15f, 0);
            firstFunc = 1;
        }

        Ciduk();
    }

    private void Ciduk()
    {
        if(triggerSusterJagaScript.ciduk == 1)
        {
            dialogueTriggerAutoNoTPScript.enabled = true;
        }
        else
        {
            dialogueTriggerAutoNoTPScript.enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
