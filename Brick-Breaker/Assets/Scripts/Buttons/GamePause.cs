using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource music;
    private bool isPaused = false;
    private void Start() {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        music.UnPause();
    }
    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        music.Pause();
    }
}
