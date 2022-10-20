using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatformMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private int speed = 3;
    private Vector3 direction;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (Input.touchCount == 1){
            if (Input.GetTouch(0).position.x > Screen.width / 2){
                direction = Vector3.right;
            }
            else{
                direction = Vector3.left;
            }
        }
        else{
            direction = Vector3.zero;
        }
    }
    private void FixedUpdate() {
        _rb.AddForce(direction * speed);
    }
}
