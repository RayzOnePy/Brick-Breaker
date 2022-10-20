using UnityEngine;
using TMPro;

public class DefaultBrick : MonoBehaviour
{

    private TextMeshPro hpText;
    public Material[] materials;
    private MeshRenderer color;
    private Brick brick;
    private int currentHP;
    private void Start() {
        hpText = transform.GetChild(0).GetComponent<TextMeshPro>();
        color = GetComponent<MeshRenderer>();
        brick = GetComponent<Brick>(); 
    }


    private void FixedUpdate(){
        if (brick.hp != currentHP){
            currentHP = brick.hp;
            hpText.text = $"{currentHP}";
            ChangeColor();
        }
    }
    private void ChangeColor(){
        if (brick.hp > 50 && brick.hp <= 100){
            color.material = materials[0];
        }
        if (brick.hp > 25 && brick.hp <= 50){
            color.material = materials[1];
        }
        if (brick.hp > 10 && brick.hp <= 25){
            color.material = materials[2];
        }
        if (brick.hp > 5 && brick.hp <= 10){
            color.material = materials[3];
        }
        if (brick.hp > 3 && brick.hp <= 5){
            color.material = materials[4];
        }
        if (brick.hp > 1 && brick.hp <= 3){
            color.material = materials[5];
        }
        if (brick.hp == 1){
            color.material = materials[6];
        }
    }
}