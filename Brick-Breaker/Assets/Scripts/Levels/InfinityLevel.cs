using UnityEngine;
using TMPro;

public class InfinityLevel : MonoBehaviour
{
    private TextMeshProUGUI ballCounter;
    private GameObject balls;
    private bool gameIsOver = false;
    public AudioSource _audio;
    public AudioClip clip;
    public GameObject levelMenu;
    public TextMeshProUGUI score;
    public TextMeshProUGUI title;
    public TextMeshProUGUI newScore;
    public GameObject[] levels;
    private void Start() {
        Score.score = 0;
        UnlockLevel();
        ballCounter = GameObject.FindGameObjectWithTag("BallCounter").GetComponent<TextMeshProUGUI>();
        balls = GameObject.FindGameObjectWithTag("Balls");
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    private void FixedUpdate() {
        score.text = $"Score : {Score.score}";
        ballCounter.text = balls.transform.childCount.ToString();
        if (balls.transform.childCount == 0 && gameIsOver == false){
            levelMenu.SetActive(true);
            title.text = $"Your score : {Score.score}";
            if (Score.score > PlayerPrefs.GetInt("MaxScore")){
                PlayerPrefs.SetInt("MaxScore", Score.score);
                newScore.text = "NeW ReCoRd!!!";
            }
            else{
                newScore.text = "";
            }
            gameIsOver = true;
            _audio.PlayOneShot(clip);
        }
        if (transform.GetChild(0).childCount == 0 && gameIsOver == false){
            Destroy(transform.GetChild(0).gameObject);
            int rand = Random.Range(0, levels.Length);
            Instantiate(levels[rand], new Vector3(0, 0, 0), Quaternion.identity, transform);
        }
    }
    private void UnlockLevel(){
        if (PlayerPrefs.GetInt("unlockedLevels") < 7){
            PlayerPrefs.SetInt("unlockedLevels", 7);
        }
    }
}
