using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPramuJalan : MonoBehaviour
{

    public Animator animator;
    public BoxCollider2D colliderr;

    private void Start()
    {
        //colliderr = GetComponent<BoxCollider2D>();
    }

    public void PramugariJalan()
    {

        animator.SetBool("PramugariJalanKeRussia", true);
        colliderr.enabled = false;
    }

    public void PramugariJalanLavatory()
    {
        Debug.Log("DiaJalan");
        animator.SetBool("PramugariJalanKeAnak", true);
        colliderr.enabled = false;
    }

}
