using UnityEngine;

public class BorderCreate : MonoBehaviour
{
    public GameObject[] border;
    public float offset;
    private void Start() {
        Vector2 left = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 up = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Instantiate(border[0], new Vector3(left.x - offset, 0, 0), Quaternion.identity);
        Instantiate(border[1], new Vector3(-left.x + offset, 0, 0), Quaternion.identity);
        Instantiate(border[2], new Vector3(0, up.y + offset, 0), Quaternion.identity);
    }
}
