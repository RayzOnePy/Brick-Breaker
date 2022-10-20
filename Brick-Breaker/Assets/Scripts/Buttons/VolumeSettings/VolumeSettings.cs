using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public GameObject musicSettings;
    public GameObject soundSettings;
    public AudioSource _music;
    public AudioSource _sound;
    public AudioClip clip;
    private float musicValue;
    private float soundValue;
    private void Start() {
        if (PlayerPrefs.HasKey("MusicValue")){
            musicSettings.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicValue");
            _music.volume = PlayerPrefs.GetFloat("MusicValue");
        } else {
            musicSettings.GetComponent<Slider>().value = 0.3f;
            _music.volume = 0.3f;
        }

        if (PlayerPrefs.HasKey("SoundValue")){
            soundSettings.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundValue");
            _sound.volume = PlayerPrefs.GetFloat("SoundValue");
        } else {
            soundSettings.GetComponent<Slider>().value = 0.3f;
            _sound.volume = 0.3f;
        }
    }
    public void AcceptSettings(){
        _music.volume = musicSettings.GetComponent<Slider>().value;
        _sound.volume = soundSettings.GetComponent<Slider>().value;
        _sound.PlayOneShot(clip);
        PlayerPrefs.SetFloat("MusicValue", musicSettings.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("SoundValue", soundSettings.GetComponent<Slider>().value);
    }
}
