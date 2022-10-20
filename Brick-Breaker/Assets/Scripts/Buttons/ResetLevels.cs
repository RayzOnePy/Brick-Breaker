using UnityEngine;

public class ResetLevels : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip clip;
    public void ResetLevel(){
        PlayerPrefs.DeleteKey("unlockedLevels");
        _audio.PlayOneShot(clip);
    }
}
