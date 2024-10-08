using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;


    public sound[] musicSounds;
    public AudioSource musicSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    
        }
    }

    public void Start()
    {
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        sound s = Array.Find(musicSounds, x => x.name == name);

        if (s != null) {
        musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
