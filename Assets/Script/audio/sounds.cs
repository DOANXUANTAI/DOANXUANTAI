using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class sounds 
{
    public string Name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;

    public bool isLoop;

    public AudioMixerGroup _mixer;
}
