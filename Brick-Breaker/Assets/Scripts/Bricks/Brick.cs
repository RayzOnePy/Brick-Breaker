using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hp;
    private int maxHp;
    public GameObject[] bonus;
    private void Start() {
        maxHp = hp;
    }
    private void FixedUpdate() {
        if (hp <= 0){
            Score.score += maxHp * 5;
            InstantiateBonus();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        hp -= 1;
    }
    private void InstantiateBonus(){
        int rand = Random.Range(0, 5);
            if (rand == 4){
                rand = Random.Range(0, bonus.Length);
                Instantiate(bonus[rand], transform.position, Quaternion.identity);
            }
    }
}
