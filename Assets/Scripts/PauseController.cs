using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] MouseController MController;

    [SerializeField] float SlowdownFactor = 0.05f;
    public static bool GameRunning = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
        Time.timeScale = SlowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        GameRunning = false;
        MController.enabled = false;
    }

    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f;
        GameRunning = true;
        MController.enabled = true;
    }
}
