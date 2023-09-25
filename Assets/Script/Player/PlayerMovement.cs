using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Numeric
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float normalSpeed = 5;
    [SerializeField]
    private float sprintSpeed = 10;

    //Component
    public GameObject Player;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererBayangan;
    public Animator animator;
    public Animator animatorShadow;
    public AudioSource audioJalan;

    //Script
    public DialogueManager dialogueManagerScript;


    private void SpriteFlip(float horizontalInput)
    {
        if(horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {

        if(dialogueManagerScript.bolehJalan == 1)
        { //open if1
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));


        bool isMoving = Mathf.Abs(horizontalInput) > 0f;
        animator.SetBool("isWalking", isMoving);
        animatorShadow.SetBool("isWalking", isMoving);

            if (isMoving)
            {
                if (!audioJalan.isPlaying)
                {
                    audioJalan.Play();
                }
            }
            else
            {
                audioJalan.Stop();
            }

        SpriteFlip(horizontalInput);

        if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(horizontalInput) >0f)
        {
            speed = sprintSpeed;
            animator.SetBool("isSprinting", true);
            animatorShadow.SetBool("isSprinting", true);
            audioJalan.pitch = 2.0f;
            }
        else
        {
            speed = normalSpeed;
            animator.SetBool("isSprinting", false);
            animatorShadow.SetBool("isSprinting", false);
                audioJalan.pitch = 1.5f;
            }

        } //close if1

    }


}
