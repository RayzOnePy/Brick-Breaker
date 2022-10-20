using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody _rb;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.up * 100);
    }
    private void FixedUpdate() {
        _rb.velocity = _rb.velocity.normalized * 4;
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Breakable"){
            Destroy(other.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
