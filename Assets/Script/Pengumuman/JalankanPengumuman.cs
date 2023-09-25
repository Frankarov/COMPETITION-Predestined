using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JalankanPengumuman : MonoBehaviour
{
    //script
    public DialogueTriggerAutoNoTPNew dialogueTriggerAutoNoTpNewScript;

    //numeric
    private int sudahJalan = 0;

    private void Update()
    {
        if(sudahJalan == 0)
        {
            dialogueTriggerAutoNoTpNewScript.Packet();
            sudahJalan = 1;
        }
    }


}
