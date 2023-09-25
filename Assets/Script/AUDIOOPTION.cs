using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AUDIOOPTION : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    public string volumeParameter = "Master";

    public void SetVolume(float volume)
    {
        volume = volumeSlider.value;
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(volume) * 20);
    }
}
