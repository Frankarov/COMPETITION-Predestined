using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class OptionShow : MonoBehaviour
{
    [SerializeField]
    private int loopValues;
    [SerializeField]
    private int ilmuKecelakaan;
    [SerializeField]
    private int ilmuKamus;
    [SerializeField]
    private int ilmuObat;
    [SerializeField]
    private int ilmuMasker;
    [SerializeField]
    private int sadarRusia;


    public PlayerCollide playerCollideScript;




    public DialogueManager dialogueManagerScript;
    public OptionCount optionCountScript;
    public GameObject optionA;
    public GameObject optionB;
    public GameObject optionC;
    public GameObject optionD;
    public GameObject optionAA;
    public GameObject optionBB;
    public GameObject optionCC;
    public GameObject optionDD;
    public GameObject optionAAA;
    public GameObject optionBBB;
    public GameObject optionCCC;
    public GameObject optionDDD;
    public GameObject LavatoryOptionA;
    public GameObject LavatoryOptionC;
    public GameObject LavatoryOptionB;
    public GameObject russiaOptionA;
    public GameObject russiaOptionB;
    public GameObject russiaOptionC;
    public GameObject interkomOptionA;
    public GameObject interkomOptionB;
    public GameObject interkomOptionC;

    //hospital
    public GameObject susterButtonA;
    public GameObject susterButtonB;
    public GameObject susterButtonC;
    public GameObject MomCryA;
    public GameObject MomCryB;





    //public int countNumber;
    private int countNumberShow;// = optionCountScript.countOptionCheck;
    public int OptionMuncul = 0;
    public GameTimer gameTimerScript;
    private void Start()
    {

        if (optionCountScript != null)
        {
            InitiateChoice();
        }
    }

    private void Update()
    {
        loopValues = PlayerPrefs.GetInt("Loop");
        ilmuKamus = PlayerPrefs.GetInt("ilmuKamus");
        ilmuKecelakaan = PlayerPrefs.GetInt("ilmuKecelakaan");
        ilmuMasker = PlayerPrefs.GetInt("ilmuMasker");
        ilmuObat = PlayerPrefs.GetInt("ilmuObat");
        sadarRusia = PlayerPrefs.GetInt("sadarRusia");

        if(Input.GetKeyDown(KeyCode.E))
        {
            InitiateChoice();
        }
    }

    private void InitiateChoice()
    {
        if(dialogueManagerScript.MasukDialogue == 1 && dialogueManagerScript.okBosKu == 1)
        {
            if(dialogueManagerScript.countOptionCheck == 0)
            {

            }else if(dialogueManagerScript.countOptionCheck == 1)
            {
                if(playerCollideScript.tagIndicator == 1) //tesNPC
                {
                    OptionMuncul = 1;
                    optionA.SetActive(dialogueManagerScript.countOptionCheck == 1);
                    optionB.SetActive(dialogueManagerScript.countOptionCheck == 1);
                    optionC.SetActive(dialogueManagerScript.countOptionCheck == 1);
                    optionD.SetActive(dialogueManagerScript.countOptionCheck == 1);
                }else if(playerCollideScript.tagIndicator == 7100)
                {

                    susterButtonA.SetActive(dialogueManagerScript.countOptionCheck == 1);
                    susterButtonB.SetActive(dialogueManagerScript.countOptionCheck == 1);
                    if(sadarRusia == 1)
                    {
                        susterButtonC.SetActive(dialogueManagerScript.countOptionCheck == 1);
                    }
                }


            }
            else if(dialogueManagerScript.countOptionCheck == 2)
            {
                if(playerCollideScript.tagIndicator == 2) //PramugariKokpit
                {
                    if(loopValues == 0)
                    {
                    OptionMuncul = 1;
                    optionAA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    optionCC.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    }else if(loopValues == 1)
                    {
                    OptionMuncul = 1;
                    optionAA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    optionBB.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    optionCC.SetActive(dialogueManagerScript.countOptionCheck == 2);

                        if(gameTimerScript.badaiIndex == 1)
                        {
                            optionDD.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        }
                    }





                }else if(playerCollideScript.tagIndicator == 4) //Pilot
                {
                    if (loopValues == 1)
                    {
                        if(ilmuKecelakaan == 0)
                        {
                        OptionMuncul = 1;
                        optionAAA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        optionBBB.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        optionCCC.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        }
                        else if(ilmuKecelakaan == 1){
                        OptionMuncul = 1;
                        optionAAA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        optionBBB.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        optionCCC.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        optionDDD.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        }


                    }
                }else if(playerCollideScript.tagIndicator == 5) //pramugarilavatory
                {
                    if(ilmuKamus == 1 && ilmuObat == 1 && ilmuMasker == 1)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        LavatoryOptionB.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        LavatoryOptionC.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    }else if(ilmuKamus == 0 && ilmuObat == 1 && ilmuMasker == 1)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        LavatoryOptionC.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    }
                    else if(ilmuKamus == 1 && ilmuObat == 0 && ilmuMasker == 1)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        LavatoryOptionC.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    }
                    else if(ilmuKamus == 0 && ilmuObat == 0 && ilmuMasker == 1)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        LavatoryOptionC.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    }
                    else if(ilmuKamus == 1 && ilmuObat == 1 && ilmuMasker == 0)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                        LavatoryOptionB.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    }else if(ilmuKamus == 0 && ilmuObat == 0 && ilmuMasker == 0)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);
                    }else if(ilmuKamus == 1 && ilmuObat == 0 && ilmuMasker == 0)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);

                    }
                    else if(ilmuKamus == 0 && ilmuObat == 1 && ilmuMasker == 0)
                    {
                        OptionMuncul = 1;
                        LavatoryOptionA.SetActive(dialogueManagerScript.countOptionCheck == 2);

                    }
                }
            }else if(dialogueManagerScript.countOptionCheck == 3)
            {
                if(playerCollideScript.tagIndicator == 6910)
                {
                    OptionMuncul = 1;
                    russiaOptionA.SetActive(dialogueManagerScript.countOptionCheck == 3);
                    russiaOptionB.SetActive(dialogueManagerScript.countOptionCheck == 3);
                    russiaOptionC.SetActive(dialogueManagerScript.countOptionCheck == 3);
                }else if(playerCollideScript.tagIndicator == 12345)
                {
                    OptionMuncul = 1;
                    interkomOptionA.SetActive(dialogueManagerScript.countOptionCheck == 3);
                    interkomOptionB.SetActive(dialogueManagerScript.countOptionCheck == 3);
                    interkomOptionC.SetActive(dialogueManagerScript.countOptionCheck == 3);
                }

            }else if(dialogueManagerScript.countOptionCheck == 9)
            {
                if(playerCollideScript.tagIndicator == 4444)
                {
                    MomCryA.SetActive(dialogueManagerScript.countOptionCheck == 9);
                    MomCryB.SetActive(dialogueManagerScript.countOptionCheck == 9);
                }

            }
        }





    } //tutup initiate choice

}
