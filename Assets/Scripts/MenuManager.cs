using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{
    public GameObject optionsMenu;
    public static bool GamePause = false;
    public GameObject pauseMenu;
    public GameObject volumeMenu;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !volumeMenu.active){
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
            if(GamePause){
                Resume();
            }else{
                Pause();
            }
        }else if(Input.GetKeyDown(KeyCode.Escape) && volumeMenu.active){
            volumeMenu.SetActive(false);
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
            Pause();
        }
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void QuitGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

   public void RestartLevel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("LabScene");
        Score.scoreValue = 0;
    }

}


