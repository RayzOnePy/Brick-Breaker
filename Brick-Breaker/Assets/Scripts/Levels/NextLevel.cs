using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel(){
        SceneManager.LoadScene("Level " + (int.Parse(SceneManager.GetActiveScene().name.Split(" ")[1]) + 1));
    }
}
