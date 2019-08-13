using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundList soundList;

    private void Awake()
    {
        foreach(Sound s in soundList.sounds)
        {
            s.src = gameObject.AddComponent<AudioSource>();
            s.src.clip = s.clip;
            s.src.volume = s.volume;
            s.src.pitch = s.pitch;
            s.src.loop = s.loop;
            s.src.spatialBlend = s.spatialBlend;
        }


    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(soundList.sounds, sound => sound.clipName == soundName);
        if (s == null)
        {
            Debug.Log(soundName + "does not exist.");
        }
        else
        {
            if (s.isOneShot)
            {
                s.src.PlayOneShot(s.src.clip);
            }
            else
            {
                s.src.Play();
            }
        }
    }

    public void StopSound(string soundName)
    {
        Sound s = Array.Find(soundList.sounds, sound => sound.clipName == soundName);
        if (s == null)
        {
            Debug.Log(soundName + "does not exist.");
        }
        else
        {
            s.src.Stop();
        }
    }
}
