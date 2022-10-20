using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public float hp;
    private float maxHp;
    private float cooldown = 0;
    private float shootCooldown = 5f;
    private float maxShootCooldown = 5f;
    private int rand;

    private bool isRight = true;
    private Rigidbody _rb;
    private float speed = 1;
    
    public Image hpImg;
    public Material[] bossMaterials;
    public GameObject[] ammunation;
    private void Start() {
        hp = 50;
        maxHp = hp;
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(1, 0, 0);
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ball"){
            hp -= 1;
            hpImg.fillAmount = hp / maxHp;
            if (hp <= maxHp / 2){
                speed = 1.5f;
                maxShootCooldown = 4;
                gameObject.GetComponent<MeshRenderer>().material = bossMaterials[0];
            }
            if (hp <= maxHp / 4){
                maxShootCooldown = 3.5f;
                gameObject.GetComponent<MeshRenderer>().material = bossMaterials[1];
            }
            if (hp <= 0){
                Destroy(gameObject);
            }
        }
    }
    private void FixedUpdate() {
        if (cooldown <= 0){
            if (isRight && this.transform.position.x >=  6){
                isRight = false;
                _rb.AddForce(-1000, 0, 0);
                cooldown = 2f;
            }
            if (isRight == false && this.transform.position.x <= -6){
                isRight = true;
                _rb.AddForce(1000, 0, 0);
                cooldown = 2f;
            }
        }
        if (shootCooldown <= 0){
            rand = Random.Range(1, 101);
            if (rand < 60){
                Instantiate(ammunation[0], transform.position, Quaternion.identity);
            }
            else if (rand > 70){
                Instantiate(ammunation[1], transform.position, Quaternion.identity);
            }
            else{
                Instantiate(ammunation[2], transform.position, Quaternion.identity);
            }
            shootCooldown = maxShootCooldown;
        }
        cooldown -= Time.fixedDeltaTime;
        shootCooldown -= Time.fixedDeltaTime;
        _rb.velocity = _rb.velocity.normalized * speed;
    }
}
