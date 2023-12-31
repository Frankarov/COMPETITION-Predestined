using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "speakerName",menuName = "Dialogue/newSpeaker")]

public class Speaker : ScriptableObject
{
    [SerializeField] private string speakerName;
    [SerializeField] private Sprite speakerSprite;

    public string GetName()
    {
        return speakerName;
    }

    public Sprite GetSprite()
    {
        return speakerSprite;
    }

}
