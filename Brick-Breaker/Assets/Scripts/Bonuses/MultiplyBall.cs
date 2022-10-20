using UnityEngine;

public class MultiplyBall : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject ballPref;
    private GameObject ballsBag;
    private AudioSource _audio;
    public AudioClip clip;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(-transform.up * 50);
        ballsBag = GameObject.FindGameObjectWithTag("Balls");
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BonusCollector"){
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            if (gameObject.tag == "MultiplyBall"){
                for (int i = 0; i < balls.Length; i++){
                    Instantiate(ballPref, balls[i].transform.position, Quaternion.Euler(90, 0, 0), ballsBag.transform);
                }
                _audio.PlayOneShot(clip);
            }
            else{
                if (balls.Length > 1){
                    for (int i = 0; i < balls.Length; i += 2){
                        Destroy(balls[i]);
                    }
                }
                _audio.PlayOneShot(clip);
            }
            Destroy(gameObject);
        }
    }
}
