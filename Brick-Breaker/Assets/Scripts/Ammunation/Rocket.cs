using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject ball;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(-transform.up * 50);
    }
    private void FixedUpdate() {
        _rb.velocity = _rb.velocity.normalized * 2;
        if (transform.position.y < -5){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BonusCollector"){
            ball = GameObject.FindGameObjectWithTag("Ball");
            Destroy(ball);
        }
    }
}
