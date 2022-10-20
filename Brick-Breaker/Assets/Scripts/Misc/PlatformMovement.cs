using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private int speed = 3;
    private Vector3 direction;
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (Input.GetKey(KeyCode.A)){
            direction = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D)){
            direction = Vector3.right;
        }
        else{
            direction = Vector3.zero;
        }
    }
    private void FixedUpdate() {
        _rb.AddForce(direction * speed);
    }
}
