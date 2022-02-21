using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] MouseController mouseController;

    [SerializeField] float SlowdownFactor = 0.05f;
    public static bool GameRunning = true;

    void Start() {
        SlowDownTime();    
        
    }

    public void NewGame() {
        RestoreTime();
        SceneManager.LoadScene("Level1");
    }

    public void Continue() {
        RestoreTime();
        SceneManager.LoadScene("LevelSelector");
    }

    public void Retry() {
        RestoreTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SlowDownTime() {
        if(mouseController == null)
            mouseController = FindObjectOfType(typeof(MouseController)) as MouseController;
        Time.timeScale = SlowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        GameRunning = false;
        mouseController.enabled = false;
    }
    void RestoreTime() {
        if(mouseController == null)
            mouseController = FindObjectOfType(typeof(MouseController)) as MouseController;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f;
        GameRunning = true;
        mouseController.enabled = true;
    }
}
