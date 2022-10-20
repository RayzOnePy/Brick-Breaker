using UnityEngine;

public class RandomBrick : MonoBehaviour
{
    private int hp;
    private float cooldown;
    public Material[] materials;
    private MeshRenderer color;
    private Brick brick;
    private void Start() {
        hp = Random.Range(1, 25);
        color = GetComponent<MeshRenderer>();
        brick = GetComponent<Brick>();
        brick.hp = hp;
        cooldown = 0;
    }
    private void FixedUpdate() {
        if (cooldown <= 0){
            color.material = materials[Random.Range(0, 6)];
            cooldown = 5f;
        }
        cooldown -= Time.fixedDeltaTime;
    }
}
