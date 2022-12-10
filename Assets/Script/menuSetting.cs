using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class menuSetting : MonoBehaviour
{

    [SerializeField] Slider _music;
    [SerializeField] AudioMixer _audioMix;



    private void Awake()
    {
        _music.onValueChanged.AddListener(changeValues);
    }

    public void changeValues(float values)
    {

        _audioMix.SetFloat("Musics",Mathf.Log10(values) *20);





    
    
    
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;

    }
}
