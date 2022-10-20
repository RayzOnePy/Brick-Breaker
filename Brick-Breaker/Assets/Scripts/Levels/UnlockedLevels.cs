using UnityEngine;
using UnityEngine.UI;

public class UnlockedLevels : MonoBehaviour
{
    public int unlockedLevels;
    public GameObject[] levelBtns;
    private void Start() {
        UnlockLevels();
    }
    public void UnlockLevels(){
        if (PlayerPrefs.HasKey("unlockedLevels")){
            unlockedLevels = PlayerPrefs.GetInt("unlockedLevels");
        }
        else{
            unlockedLevels = 0;
        }
        levelBtns = GameObject.FindGameObjectsWithTag("lvlBtn");
        for (int i = 0; i < levelBtns.Length; i++){
            if (unlockedLevels > i){
                levelBtns[i].GetComponent<Button>().interactable = true;
                levelBtns[i].gameObject.GetComponent<Image>().color = Color.green;
            }
            else if (unlockedLevels == i){
                levelBtns[i].GetComponent<Button>().interactable = true;
                levelBtns[i].gameObject.GetComponent<Image>().color = Color.white;
            }
            else{
                levelBtns[i].GetComponent<Button>().interactable = false;
                levelBtns[i].gameObject.GetComponent<Image>().color = Color.black;
            }
        }
    }
}
