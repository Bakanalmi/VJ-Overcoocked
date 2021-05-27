using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuSettings : MonoBehaviour
{


    public AudioMixer audioMixer;
    public float volume;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
         
    }
}
