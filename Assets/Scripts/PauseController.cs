using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] MouseController mouseController;

    [SerializeField] float SlowdownFactor = 0.05f;
    public static bool GameRunning = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !TextBoxManager.Instance.IsTextActive) {
            if (GameRunning) {
                Pause();
            }
            else {
                Resume();
            }
        }
    }

    public void Pause() {
        PauseMenuUI.SetActive(true);
        SlowDownTime();
    }

    public void Resume() {
        PauseMenuUI.SetActive(false);
        RestoreTime();
    }

    public void Retry() {
        RestoreTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        RestoreTime();
        SceneManager.LoadScene("LevelSelector");
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
