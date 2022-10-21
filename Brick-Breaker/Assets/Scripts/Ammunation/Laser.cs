using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody _rb;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.up * 100);
    }
    private void FixedUpdate() {
        _rb.velocity = new Vector3(0, 4, 0);
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Breakable"){
            other.gameObject.GetComponent<Brick>().hp -= 99;
        }
        else{
            Destroy(gameObject);
        }
    }
}
