using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    //Script untuk tentuin trigger mana


    public int tagIndicator = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NonsenseTrigger"))
        {
            tagIndicator = 0;
        }else if (collision.CompareTag("TesTrigger"))
        {
            tagIndicator = 1;
        }else if (collision.CompareTag("PramugariTrigger2"))
        {
            tagIndicator = 2;
        }else if (collision.CompareTag("KeypadTrigger"))
        {
            tagIndicator = 3;
        }else if (collision.CompareTag("PilotTrigger"))
        {
            tagIndicator = 4;
        }else if (collision.CompareTag("PramugariLavaTrigger"))
        {
            tagIndicator = 5;
        }else if (collision.CompareTag("Russia00"))
        {
            tagIndicator = 6900;
        }
        else if (collision.CompareTag("Russia10"))
        {
            tagIndicator = 6910;
        }
        else if (collision.CompareTag("Russia01"))
        {
            tagIndicator = 6901;
        }
        else if (collision.CompareTag("Russia11"))
        {
            tagIndicator = 6911;
        }
        else if (collision.CompareTag("Russia111"))
        {
            tagIndicator = 69111;
        }else if (collision.CompareTag("Interkom"))
        {
            tagIndicator = 12345;
        }else if (collision.CompareTag("DokterSusterDatang"))
        {
            tagIndicator = 7000;
        }else if (collision.CompareTag("SusterPergi"))
        {
            tagIndicator = 7100;
        }else if (collision.CompareTag("televisi"))
        {
            tagIndicator = 7200;
        }else if (collision.CompareTag("SusterJaga"))
        {
            tagIndicator = 555;
        }else if (collision.CompareTag("MomCry"))
        {
            tagIndicator = 4444;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("TesTrigger") && tagIndicator == 1)
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("PramugariTrigger2"))
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("KeypadTrigger"))
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("PilotTrigger"))
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("PramugariLavaTrigger"))
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("Russia00"))
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("Russia10"))
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("Russia01"))
        {
            tagIndicator = 6901;
        }
        else if (collision.CompareTag("Russia11"))
        {
            tagIndicator = 0;
        }
        else if (collision.CompareTag("Russia111"))
        {
            tagIndicator = 0;
        }else if (collision.CompareTag("Interkom"))
        {
            tagIndicator = 0;
        }else if (collision.CompareTag("DokterSusterDatang"))
        {
            tagIndicator = 0;
        }else if (collision.CompareTag("SusterPergi"))
        {
            tagIndicator = 0;
        }else if (collision.CompareTag("televisi"))
        {
            tagIndicator = 0;
        }else if (collision.CompareTag("SusterJaga"))
        {
            tagIndicator = 0;
        }else if (collision.CompareTag("MomCry"))
        {
            tagIndicator = 0;
        }
    }
}
