using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

       // DontDestroyOnLoad(gameObject);

        //Array of sounds which contain all the functionality of the sounds
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    //Method to play the sound
    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }

    //Method to Stop the sound
    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();

    }

    //Method to delay certain sound from given set of time period
    public void Delay(string name, float fromSeconds, float toSecond)
    {
       Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.time = fromSeconds;
        s.source.Play();
        s.source.SetScheduledEndTime(AudioSettings.dspTime + (toSecond - fromSeconds));
    }
    public void Pause(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }


    private void Start()
    {
        //Play("Background");
    }
}
