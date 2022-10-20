using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BossLevel : MonoBehaviour
{
    private TextMeshProUGUI ballCounter;
    private GameObject balls;
    public AudioSource _audio;
    public AudioClip[] clips;
    public GameObject levelMenu;
    public GameObject nextLvlBtn;
    public TextMeshProUGUI winOrLose;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI totalTimer;
    private float time;
    private bool gameIsOver = false;
    private void Start() {
        ballCounter = GameObject.FindGameObjectWithTag("BallCounter").GetComponent<TextMeshProUGUI>();
        balls = GameObject.FindGameObjectWithTag("Balls");
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    private void FixedUpdate() {
        ballCounter.text = balls.transform.childCount.ToString();
        timer.text = $"Time : {Mathf.Ceil(time)}";
        if (transform.childCount == 0 && gameIsOver == false){
            levelMenu.SetActive(true);
            winOrLose.text = "You Win!";
            totalTimer.text = $"Time : {Mathf.Ceil(time)}";
            gameIsOver = true;
            UnlockLevel();
            _audio.PlayOneShot(clips[0]);
        }
        if (balls.transform.childCount == 0 && gameIsOver == false){
            levelMenu.SetActive(true);
            nextLvlBtn.SetActive(false);
            winOrLose.text = "You Lose!";
            totalTimer.text = " ";
            gameIsOver = true;
            _audio.PlayOneShot(clips[1]);
        }
        if (gameIsOver == false){
            time += Time.fixedDeltaTime;
        }
    }
    private void UnlockLevel(){
        if (PlayerPrefs.GetInt("unlockedLevels") < int.Parse(SceneManager.GetActiveScene().name.Split(" ")[1])){
            PlayerPrefs.SetInt("unlockedLevels", PlayerPrefs.GetInt("unlockedLevels") + 1);
        }
    }
}
