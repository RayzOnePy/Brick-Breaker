using UnityEngine;
using UnityEngine.SceneManagement;
public class Home : MonoBehaviour
{
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
