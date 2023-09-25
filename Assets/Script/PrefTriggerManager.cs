using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PrefTriggerManager : MonoBehaviour
{
    //Numeric
    private int loopIndex;
    private int ilmuKecelakaan;
    private int ilmuKamus;
    private int ilmuObat;
    private int ilmuMasker;
    private int setelahBadai;
    

    //Script
    public DialogueManager dialogueManagerScript;
    public GameTimer gameTimerScript;
    public ObatRussia obatRussiaScript;
    public ToiletScript toiletScriptScript;

    //ColliderTrigger
    public BoxCollider2D colliderKeypad;
    public BoxCollider2D colliderKom;

    public BoxCollider2D colliderPramugariKokpitLoop0;
    public BoxCollider2D colliderPramugariKokpitLoop1;

    public BoxCollider2D russia00;
    public BoxCollider2D russia10;
    public BoxCollider2D russia01;
    public BoxCollider2D russia11;
    public BoxCollider2D russia111;

    public BoxCollider2D momkidBeforeToilet;
    public BoxCollider2D momKidAfterToilet;
    public BoxCollider2D momKidAfterBadai;

    private int pramukokpitjalan = 0;

    private int deus; private int deus2;

    private void Start()
    {
        setelahBadai = 1;
    }
    public void penghitunganimasi()
    {
        pramukokpitjalan = 1;
    }
    private void Update()
    {
        loopIndex = PlayerPrefs.GetInt("Loop");
        ilmuKecelakaan = PlayerPrefs.GetInt("ilmuKecelakaan");
        ilmuKamus = PlayerPrefs.GetInt("ilmuKamus");
        ilmuObat = PlayerPrefs.GetInt("ilmuObat");
        ilmuMasker = PlayerPrefs.GetInt("ilmuMasker");
        

        if(dialogueManagerScript.diKick == 1 && colliderKeypad.enabled == true)
        {
            Debug.Log("ColliderKeypadDimatikan");
            colliderKeypad.enabled = false;
            //colliderKom.enabled= false;
        }

        if(loopIndex == 0 && pramukokpitjalan == 0)
        {
            colliderPramugariKokpitLoop0.enabled = true;
            colliderPramugariKokpitLoop1.enabled = false;

        }
        else if(loopIndex == 1 && gameTimerScript.badaiIndex == 0 && pramukokpitjalan == 0)
        {
            colliderPramugariKokpitLoop0.enabled = true;
            colliderPramugariKokpitLoop1.enabled = false;
        }else if(loopIndex == 1 && gameTimerScript.badaiIndex == 1 && pramukokpitjalan == 0)
        {
            colliderPramugariKokpitLoop0.enabled = false;
            colliderPramugariKokpitLoop1.enabled = true;
        }else if(pramukokpitjalan == 1)
        {
            colliderPramugariKokpitLoop0.enabled = false;
            colliderPramugariKokpitLoop1.enabled = false;
        }


        //00 10 01 11 111 RUSSIA
        if(ilmuKamus == 0)
        {
            if(gameTimerScript.badaiIndex == 0)
            {
                russia00.enabled = true;
                russia01.enabled = false; russia11.enabled = false; russia10.enabled = false; russia111.enabled = false;
            }else if(gameTimerScript.badaiIndex == 1)
            {
                russia01.enabled = true;
                russia00.enabled = false; russia11.enabled = false; russia10.enabled = false; russia111.enabled = false;
            }

        }else if(ilmuKamus == 1)
        {
            if(gameTimerScript.badaiIndex == 0)
            {
                russia10.enabled = true;
                russia01.enabled = false; russia11.enabled = false; russia00.enabled = false; russia111.enabled = false;
            }
            else if(gameTimerScript.badaiIndex == 1)
            {

                if (obatRussiaScript.dapatObat == 1)
                {

                    if(dialogueManagerScript.russiaCured == 1)
                    {
                        russia111.enabled = false; russia01.enabled = false; russia11.enabled = false; russia10.enabled = false; russia00.enabled = false;
                    }else if(dialogueManagerScript.russiaCured == 0)
                    {
                        russia111.enabled = true;
                        russia01.enabled = false; russia11.enabled = false; russia10.enabled = false; russia00.enabled = false;
                    }

                }else if(obatRussiaScript.dapatObat == 0)
                {
                    russia11.enabled = true;
                    russia01.enabled = false; russia00.enabled = false; russia10.enabled = false; russia111.enabled = false;
                }
            }

        } //russia siap

        if(toiletScriptScript.masukToilet == 0)
        {
            momkidBeforeToilet.enabled = true;
            momKidAfterToilet.enabled = false; momKidAfterBadai.enabled = false;
        }else if(toiletScriptScript.masukToilet == 1 && gameTimerScript.badaiIndex == 0)
        {
            momkidBeforeToilet.enabled = false;
            momKidAfterToilet.enabled = true; momKidAfterBadai.enabled = false;
        }else if(gameTimerScript.badaiIndex == 1 && toiletScriptScript.masukToilet == 1)
        {
            momKidAfterBadai.enabled = true;
            momkidBeforeToilet.enabled = false; momKidAfterToilet.enabled = false;
        }

    }//close void update



}
