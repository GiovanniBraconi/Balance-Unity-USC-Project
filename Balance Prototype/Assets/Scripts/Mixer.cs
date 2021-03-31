using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour
{
    public AudioMixer mixer;
    
    
    public void FadeVolume()
      {
        StartCoroutine(FadeMixerGroup.StartFade( mixer, "levelMusic", 0.2f, 0.5f));
    }
}
