using UnityEngine;

public class OpenLevelMenu : MonoBehaviour
{
    public GameObject menu;
    private AudioSource _audio;
    public AudioClip clip;
    private void Start() {
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    public void OpenMenu(){
        menu.SetActive(true);
        _audio.PlayOneShot(clip);
    }
}
