using UnityEngine;

public class CloseLevelMenu : MonoBehaviour
{
    public GameObject menu;
    private AudioSource _audio;
    public AudioClip clip;
    private void Start() {
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    public void CloseMenu(){
        menu.SetActive(false);
        _audio.PlayOneShot(clip);
    }
}
