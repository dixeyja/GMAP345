using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
public class MusicController : MonoBehaviour
{
    public PlayerStatus status;
    private AudioManager am;
    private string currentSong = "DungeonAmbience";
    private bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        am = gameObject.GetComponent<AudioManager>();

        PlaySong(currentSong);
    }

    public void PlaySong(string songName)
    {
        Debug.Log(songName);

        if (playing)
        {
            am.StopSound(currentSong);

        }

        currentSong = songName;
        am.PlaySound(currentSong);
        playing = true;
    }
}
