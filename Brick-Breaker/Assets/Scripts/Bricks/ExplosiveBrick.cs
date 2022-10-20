using UnityEngine;

public class ExplosiveBrick : MonoBehaviour
{
    private Brick brick;
    private void Start() {
        brick = GetComponent<Brick>(); 
    }
    private void OnCollisionEnter(Collision other) {
        DestroyAround();
        Destroy(gameObject);
    }
    public void DestroyAround(){
        RaycastHit hit;
        Ray rayR = new Ray(transform.position, new Vector3(2, 0, 0));
        Ray rayL = new Ray(transform.position, new Vector3(-2, 0, 0));
        Ray rayU = new Ray(transform.position, new Vector3(0, 2, 0));
        Ray rayD = new Ray(transform.position, new Vector3(0, -2, 0));

        Physics.Raycast(rayR, out hit);
        if (hit.transform.gameObject.tag == "Breakable"){
            hit.transform.gameObject.GetComponent<Brick>().hp -= 99;
        }
        Physics.Raycast(rayL, out hit);
        if (hit.transform.gameObject.tag == "Breakable"){
            hit.transform.gameObject.GetComponent<Brick>().hp -= 99;
        }
        Physics.Raycast(rayU, out hit);
        if (hit.transform.gameObject.tag == "Breakable"){
            hit.transform.gameObject.GetComponent<Brick>().hp -= 99;
        }
        Physics.Raycast(rayD, out hit);
        if (hit.transform.gameObject.tag == "Breakable"){
            hit.transform.gameObject.GetComponent<Brick>().hp -= 99;
        }
    }
}
