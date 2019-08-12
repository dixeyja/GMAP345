using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public List<Sound> Sounds = new List<Sound>();
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.src = gameObject.AddComponent<AudioSource>();
            s.src.clip = s.clip;
            s.src.volume = s.volume;
            s.src.pitch = s.pitch;
            s.src.loop = s.loop;
            s.src.spatialBlend = s.spatialBlend;
        }
    }

    private void Start()
    {
        PlaySound("Dungeon Ambience");
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.clipName == soundName);
        if (s == null)
        {
            Debug.Log(soundName + "does not exist.");
        }
        else
        {
            s.src.Play();
        }
    }
}
