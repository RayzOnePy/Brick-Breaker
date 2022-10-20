using UnityEngine;

public class IncreasePlatform : MonoBehaviour
{
    private Rigidbody _rb;
    private AudioSource _audio;
    public AudioClip clip;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(-transform.up * 50);
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BonusCollector"){
            GameObject platform = GameObject.FindGameObjectWithTag("Platform");
            if (other.gameObject.tag == "IncreasePlatform"){
                platform.transform.localScale = new Vector3(4, 0.35f, 1);
                _audio.PlayOneShot(clip);
            }
            else{
                platform.transform.localScale = new Vector3(3, 0.35f, 1);
                _audio.PlayOneShot(clip); 
            }
            Destroy(gameObject);
        }
    }
}
