using UnityEngine;

public class TopDeadlyBrick : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        var parent = transform.parent.gameObject;
        Destroy(parent);
    }
}
