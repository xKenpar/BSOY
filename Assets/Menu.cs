using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] float SlowdownFactor = 0.05f;
    public static bool GameRunning = true;

    [SerializeField] Text Continue31;

    void Start() {
        if(PlayerPrefs.GetInt("LevelNumber", 1) == 1){
            Continue31.color = new Color(0,0,0,.5f);
        }
    }

    public void NewGame() {
        SceneManager.LoadScene("Level1");
    }

    public void Continue() {
        if(PlayerPrefs.GetInt("LevelNumber", 1) != 1)
            SceneManager.LoadScene("LevelSelector");
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
