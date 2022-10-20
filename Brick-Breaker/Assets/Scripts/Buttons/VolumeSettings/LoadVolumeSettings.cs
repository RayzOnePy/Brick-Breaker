using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVolumeSettings : MonoBehaviour
{
    public AudioSource _music;
    public AudioSource _sound;
    private void Start() {
        if (PlayerPrefs.HasKey("MusicValue")){
            _music.volume = PlayerPrefs.GetFloat("MusicValue");
        } else {
            _music.volume = 1;
        }

        if (PlayerPrefs.HasKey("SoundValue")){
            _sound.volume = PlayerPrefs.GetFloat("SoundValue");
        } else {
            _sound.volume = 1;
        }
    }
}
