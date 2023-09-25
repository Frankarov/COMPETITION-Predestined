using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{

    public OptionShow optionShowScript;
    public int countOptionCheck;
    public PlayerCollide playerCollideScript;

    public int identify;
    public bool complete;
    public bool interruptTyping = false;

    public Text speakerName, dialogue;
    public Image speakerSprite;
    private static DialogueManager instance;
    public int MasukDialogue = 0;
    private int currentIndex;
    private Conversation currentConvo;
    private Animator anim;
    public Coroutine typing;

    public int bolehJalan = 1;
    public int buttonTouched = 1;
    public int izinAuto = 1;

    //preftrigger stuff
    [Header("Misc")]
    public int diKick = 0; //dikick dri kokpit
    public int diKickInterkom = 0;
    public int russiaCured = 0;
    public int pikiranRussia = 0;
    public int pengumumanSiap = 0;

    //hospital
    public int dokterSusterDatangSiap = 0;
    public int susterJalanKeluar;
    public int televisiSiap = 0;
    public int diTangkapSuster = 0;

    public Animator playerJalan;
    public Animator shadowJalan;
    public bool diaState;

    public Animator animatorDialog;
    
    public int okBosKu = 0;
    public AudioSource audioSource;
    public AudioSource audioIlmu;
    public AudioSource audioInterkom;
    private int hehe = 0;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void StartConversation(Conversation convo)
    {
        instance.anim.SetBool("DiaOpen", true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.readNext();
        instance.countOptionCheck = 0;
        instance.playerJalan.SetBool("isWalking", false);
        instance.playerJalan.SetBool("isSprinting", false);
        instance.shadowJalan.SetBool("isWalking", false);
        instance.shadowJalan.SetBool("isSprinting", false);
    }

    public void readNext()
    {

        if(currentIndex>currentConvo.GetLength())
        {
            countOptionCheck = 0;
            Debug.Log("The Convo Finished");
            instance.anim.SetBool("DiaOpen", false);
            MasukDialogue = 0;
            buttonTouched = 0;

            if(playerCollideScript.tagIndicator == 3) //keypad
            {
            bolehJalan = 0;
            }
            else
            {
                Debug.Log("balekbisajalan");
                bolehJalan = 1;
            }

            if(playerCollideScript.tagIndicator == 4) //pilot kokpit
            {
                diKick = 1;
            }

            if(playerCollideScript.tagIndicator == 12345) //interkom
            {
                diKickInterkom = 1;
            }

            if(playerCollideScript.tagIndicator == 6900)
            {
                pikiranRussia = 1;
            }

            if(playerCollideScript.tagIndicator == 7000)
            {
                dokterSusterDatangSiap = 1;
            }

            if(playerCollideScript.tagIndicator == 7100)
            {
                susterJalanKeluar = 1;
            }

            if(playerCollideScript.tagIndicator == 7200)
            {
                televisiSiap = 1;
            }

            if(playerCollideScript.tagIndicator == 555)
            {
                diTangkapSuster = 1;
            }

            if(playerCollideScript.tagIndicator == 69111) //kasi obat ke russia
            {
                PlayerPrefs.SetInt("rusiaSelamat", 1);
                audioIlmu.Play();
                russiaCured = 1;
            }

            if (identify == 2)
            {
                izinAuto = 0;
            }
            else
            {

            }

            return;

        }

        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();

        if(typing == null)
        {
            typing = instance.StartCoroutine(TypeTest(currentConvo.GetLineByIndex(currentIndex).Dialogue));
        }
        else
        {
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(TypeTest(currentConvo.GetLineByIndex(currentIndex).Dialogue));

        }

        // dialogue.text = currentConvo.GetLineByIndex(currentIndex).Dialogue;
        currentIndex++;
        

    }
    private IEnumerator TypeTest(string text)
    {
        dialogue.text = "";
        complete = false;
        int index = 0;
        if(text == "")
        {

        }
        else
        {
        audioSource.Play();
        }
        




        while (!complete && index < text.Length)
        {
            if (interruptTyping)
            {
                dialogue.text = text;
                interruptTyping = false;
                complete = true;
                audioSource.Stop();
                break;
            }
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);

            if(index == text.Length)
            {
                complete = true;
                audioSource.Stop();
            }
        }

        typing = null;

    }

    private void Update()
    {

        diaState = anim.GetBool("DiaOpen");


        if(buttonTouched == 1 && Input.GetKeyDown(KeyCode.E) && complete == true && diaState == true && okBosKu == 1)
        {
            Hitung();
            if(playerCollideScript.tagIndicator == 12345 && hehe == 0)
            {
                audioInterkom.Play();
                hehe = 1;
            }
        }


        if (Input.GetKeyDown(KeyCode.E) && !complete && typing != null)
        {
            interruptTyping = true;
        }
        else if (optionShowScript.OptionMuncul == 0 && Input.GetKeyDown(KeyCode.E) && complete == true && diaState == true && okBosKu == 1)
        {

            Debug.Log("E Pressed : DIALOGUE NEXT !");
            readNext();
        }

    

    }

    public void UdahSiapBos()
    {
        okBosKu = 1;
    }

    public void OkUdahSiapBos()
    {
        okBosKu = 0;
    }



    private void Hitung()
    {
        countOptionCheck++;
    }


}
