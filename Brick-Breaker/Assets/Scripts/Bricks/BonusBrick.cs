using UnityEngine;

public class BonusBrick : MonoBehaviour
{
    public int hp;
    public GameObject[] bonus;
    private void FixedUpdate() {
        if (hp <= 0){
            Destroy(gameObject);
            InstantiateBonus();
        }
    }
    private void OnCollisionEnter(Collision other) {
        hp -= 1;
    }
    private void InstantiateBonus(){
        int rand = Random.Range(0, bonus.Length);
        Instantiate(bonus[rand], transform.position, Quaternion.identity);
    }
}
