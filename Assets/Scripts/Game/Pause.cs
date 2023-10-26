using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;
    public Button exitButton;

    private void Awake(){
        pauseMenu .SetActive(false);
        pauseButton.onClick.AddListener(OnPausePressed);
        resumeButton.onClick.AddListener(OnResumePressed);
        exitButton.onClick.AddListener(OnExitPressed);
    }

    void OnPausePressed(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void OnResumePressed(){
        Time.timeScale = 1; 
        pauseMenu.SetActive(false);
    }

    void OnExitPressed(){
        Application.Quit();
    }
}
