using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStartConvo : MonoBehaviour
{

    public Conversation convo;
    public void startConvo()
    {
        DialogueManager.StartConversation(convo);
    }
}
