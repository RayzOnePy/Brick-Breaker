using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelManager : MonoBehaviour
{
    private TextMeshProUGUI brickCounter;
    private TextMeshProUGUI ballCounter;
    private GameObject balls;
    public AudioSource _audio;
    public AudioClip[] clips;
    public GameObject levelMenu;
    public GameObject nextLvlBtn;
    public TextMeshProUGUI winOrLose;
    public TextMeshProUGUI score;
    public TextMeshProUGUI totalScore;
    private bool gameIsOver = false;
    private void Start() {
        brickCounter = GameObject.FindGameObjectWithTag("BrickCounter").GetComponent<TextMeshProUGUI>();
        ballCounter = GameObject.FindGameObjectWithTag("BallCounter").GetComponent<TextMeshProUGUI>();
        balls = GameObject.FindGameObjectWithTag("Balls");
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    private void FixedUpdate() {
        brickCounter.text = $"{transform.childCount} Bricks";
        ballCounter.text = balls.transform.childCount.ToString();
        score.text = $"Score : {Score.score}";
        if (transform.childCount == 0 && gameIsOver == false){
            levelMenu.SetActive(true);
            winOrLose.text = "You Win!";
            totalScore.text = $"Your score : {Score.score}";
            gameIsOver = true;
            UnlockLevel();
            _audio.PlayOneShot(clips[0]);
        }
        if (balls.transform.childCount == 0 && gameIsOver == false){
            levelMenu.SetActive(true);
            nextLvlBtn.SetActive(false);
            winOrLose.text = "You Lose!";
            totalScore.text = "";
            gameIsOver = true;
            _audio.PlayOneShot(clips[1]);
        }
    }
    private void UnlockLevel(){
        if (PlayerPrefs.GetInt("unlockedLevels") < int.Parse(SceneManager.GetActiveScene().name.Split(" ")[1])){
            PlayerPrefs.SetInt("unlockedLevels", PlayerPrefs.GetInt("unlockedLevels") + 1);
            Debug.Log("Compleate");
        }
    }

}
