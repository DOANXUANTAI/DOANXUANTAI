using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public
    sounds[] sound;
    
    private void Awake()
    {
        foreach (var item in sound)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.volume = item.volume;
            item.source.pitch = item.pitch;
            item.source.loop = item.isLoop;
            item.source.outputAudioMixerGroup = item._mixer;
    



        }

        play("groundMusic");


        

    }



 

    public void play(string name)
    {
       sounds s =Array.Find(sound, sound => sound.Name == name);


        s.source.Play();
    }    
}
