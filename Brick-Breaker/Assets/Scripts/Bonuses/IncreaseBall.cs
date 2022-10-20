using UnityEngine;

public class IncreaseBall : MonoBehaviour
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
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject ball in balls){
                if (gameObject.tag == "IncreaseBall"){
                    ball.transform.localScale = new Vector3(0.8f, 0.1f, 0.8f);
                    _audio.PlayOneShot(clip);
                }
                else{
                    ball.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
                    _audio.PlayOneShot(clip);
                }
            }
            Destroy(gameObject);
        }
    }
}
