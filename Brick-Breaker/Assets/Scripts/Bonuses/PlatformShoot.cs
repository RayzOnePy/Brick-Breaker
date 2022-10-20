using UnityEngine;

public class PlatformShoot : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject platform;
    public GameObject[] ammunition;
    private AudioSource _audio;
    public AudioClip clip;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(-transform.up * 50);
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BonusCollector"){
            platform = GameObject.FindGameObjectWithTag("Platform");
            Instantiate(ammunition[Random.Range(0, 1)], platform.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            _audio.PlayOneShot(clip);
            Destroy(gameObject);
        }
    }
}
