using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KardusKenaCiduk : MonoBehaviour
{
    public TriggerSusterJaga triggerSusterJagaScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SusterJaga"))
        {
            triggerSusterJagaScript.dapatKau = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SusterJaga"))
        {
            triggerSusterJagaScript.dapatKau = 0;
        }
    }
}
