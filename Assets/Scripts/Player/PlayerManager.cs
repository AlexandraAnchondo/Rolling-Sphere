using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using TMPro;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour{
    public static bool levelStarted; 
    public static bool gameOver;
    
    public GameObject startMenuPanel;
    public GameObject gameOverPanel;
    public GameObject runningPanel;
    
    public static int moras; 
    public static int stardust;
    public static int score;
    
    public TextMeshProUGUI morasText; 
    public TextMeshProUGUI stardustText; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI HS;
    
    void Start(){
        gameOver = levelStarted = false; 
        startMenuPanel.SetActive(true);
        runningPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        moras = 0; 
        stardust = 0;
        score = 0; 
        //PlayerPrefs.DeleteAll();
    }

    void Update(){
        morasText.text = (PlayerPrefs.GetInt("TotalMoras", 0) + moras).ToString();
        stardustText.text = (PlayerPrefs.GetInt("TotalStardust", 0) + stardust).ToString();
        scoreText.text = "Score: " + score.ToString();
        HS.text = "HighScore: \n" + PlayerPrefs.GetInt("HighScore", 0);

        Touchscreen ts = Touchscreen.current;
        if(ts != null && ts.primaryTouch.press.isPressed && !levelStarted){
            if(EventSystem.current.IsPointerOverGameObject())
                return;
            levelStarted = true;
            startMenuPanel.SetActive(false);
            runningPanel.SetActive(true);
        }

        if(gameOver){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            runningPanel.SetActive(false);
            
            PlayerPrefs.SetInt("TotalMoras", PlayerPrefs.GetInt("TotalMoras", 0) + moras);
            PlayerPrefs.SetInt("TotalStardust", PlayerPrefs.GetInt("TotalStardust", 0) + stardust);
            if(score > PlayerPrefs.GetInt("HighScore", 0)){
                highScoreText.text = "New HighScore: \n" + score;
                PlayerPrefs.SetInt("HighScore", score);
            }
            this.enabled = false;
        }
    }
}
