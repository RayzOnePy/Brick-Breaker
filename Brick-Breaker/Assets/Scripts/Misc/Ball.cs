using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource _audio;
    private Rigidbody _rb;
    private float y;
    private float x;
    void Start()
    {
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(new Vector2(0, -1) * 200);
    }

    private void FixedUpdate()
    {
        y = _rb.velocity.y;
        x = _rb.velocity.x;
        if (transform.position.y < -4.5f){
            Destroy(gameObject);
        }
    }
    private void Update() {
        _rb.velocity = _rb.velocity.normalized * 5;
    }

    private void OnCollisionEnter(Collision other) {
        _audio.PlayOneShot(clip);
        if (other.gameObject.tag == "Wall"){
            _rb.velocity = new Vector3(-x, y, 0);
        }
        if (other.gameObject.tag == "Roof"){
            _rb.velocity = new Vector3(x, -y, 0);
        }
        if (other.gameObject.tag == "Platform"){
            Vector3 platformPos = other.transform.position;
            Vector3 contactPos = other.contacts[0].point;
            float newX = contactPos.x - platformPos.x;
            _rb.velocity = new Vector3(newX * 5 , 2.5f, 0);
        }
        else{
            if ((y > -1.5f && y < 1.5f) || (x > -0.3f && x < 0.3f)){
                normalizedDirection(y, x);
            }
        }
    }
    private void normalizedDirection(float y, float x){
        if (y > -2 && y < 2){
            if (y > 0){
                if (x > 0){
                    _rb.velocity = new Vector3(3, 2, 0);
                }
                if (x < 0){
                    _rb.velocity = new Vector3(-3, 2, 0);
                }
            }
            if (y < 0){
                if (x > 0){
                    _rb.velocity = new Vector3(3, -2, 0);
                }
                if (x < 0){
                    _rb.velocity = new Vector3(-3, -2, 0);
                }
            }
        }
        if (x > -0.3f && x < 0.3f){
            if (x > 0){
                _rb.AddForce(transform.right * 50);
            }
            if (x < 0){
                _rb.AddForce(-transform.right * 50);
            }        
        }
    }
}

