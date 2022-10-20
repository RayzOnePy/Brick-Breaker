using UnityEngine;

public class MoveableBrick : MonoBehaviour
{
    public Vector3 startPos;
    private Rigidbody _rb;
    private float cooldown = 0;
    private bool isRight = true;
    [Range(2, 10)]
    public int range;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        startPos = this.transform.position;
        _rb.AddForce(1, 0, 0);
    }
    private void FixedUpdate() {
        if (cooldown <= 0){
            if (isRight && this.transform.position.x >= startPos.x + range ){
                isRight = false;
                _rb.AddForce(-100, 0, 0);
                cooldown = 2f;
            }
            if (isRight == false && this.transform.position.x <= startPos.x - range ){
                isRight = true;
                _rb.AddForce(100, 0, 0);
                cooldown = 2f;
            }
        }
        cooldown -= Time.fixedDeltaTime;
        _rb.velocity = _rb.velocity.normalized;

    }
}
