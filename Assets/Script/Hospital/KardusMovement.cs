using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KardusMovement : MonoBehaviour
{
    //Numeric
    [SerializeField]
    private int speed = 5;

    //Component

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    //Script
    public DialogueManager dialogueManagerScript;
    public TriggerSusterJaga triggerSusterJagaScript;
    public AudioSource audioKardusJalan;

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            if(triggerSusterJagaScript.dapatKau == 1)
            {
                triggerSusterJagaScript.diaGerak = 1;
            }
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            if (triggerSusterJagaScript.dapatKau == 1)
            {
                triggerSusterJagaScript.diaGerak = 1;
            }
        }else if(horizontalInput == 0)
        {
            if (triggerSusterJagaScript.dapatKau == 1)
            {
                triggerSusterJagaScript.diaGerak = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (dialogueManagerScript.bolehJalan == 1)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));


            bool isMoving = Mathf.Abs(horizontalInput) > 0f;
            animator.SetBool("KardusIsWalking", isMoving);
            SpriteFlip(horizontalInput);

            if (isMoving)
            {
                if (!audioKardusJalan.isPlaying)
                {
                    audioKardusJalan.Play();
                }
            }
        }

        
    }
}
