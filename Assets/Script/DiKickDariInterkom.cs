using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiKickDariInterkom : MonoBehaviour
{
    //Komponen
    public BoxCollider2D colliderInterkom;
    public BoxCollider2D colliderKeypad;


    //Script
    public DialogueManager dialogueManagerScript;

    private void Update()
    {
        if(dialogueManagerScript.diKickInterkom == 0 && dialogueManagerScript.diKick == 0)
        {
            colliderInterkom.enabled = true;
            colliderKeypad.enabled = true;
        }else if(dialogueManagerScript.diKickInterkom == 1 || dialogueManagerScript.diKick == 1)
        {
            colliderInterkom.enabled = false;
            colliderKeypad.enabled = false;
        }
    }
}
