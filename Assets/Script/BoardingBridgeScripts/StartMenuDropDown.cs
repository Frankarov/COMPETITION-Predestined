using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuDropDown : MonoBehaviour
{

    //Numeric
    private int animationInt = 0;

    //Component
    private static StartMenuDropDown instance;
    private Animator anim;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {

        if(animationInt == 0)
        {
            AnimationStartMenuDropDown();

        }else if(animationInt == 1)
        {
            AnimationStartMenuStay();
        }
    }

    private void AnimationStartMenuDropDown()
    {
        instance.anim.SetTrigger("TriggerStartMenuDropDown");
        animationInt = 1;
    }

    private void AnimationStartMenuStay()
    {
        instance.anim.SetTrigger("TriggerStartMenuStay");
    }

    public void AnimationStartMenuClimbUp()
    {
        instance.anim.SetTrigger("TriggerStartMenuClimbUp");
    }


}
