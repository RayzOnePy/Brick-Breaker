using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip clip;
    private void Start() {
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    public void LevelLoad(){
        _audio.PlayOneShot(clip);
        SceneManager.LoadScene("Level " + gameObject.name.Split(" ")[1]);
    }
}
