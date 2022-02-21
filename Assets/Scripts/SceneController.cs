using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public int currentLevel = 15;
    int maxLevel = 16;

    static SceneController instance = null;
    
    public static SceneController Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType(typeof(SceneController)) as SceneController;

            return instance;
        }
    }

    void Start() {
        Debug.Log(PlayerPrefs.GetInt("LevelNumber", 1));    
    }

    public void NextLevel(){
        if(PlayerPrefs.GetInt("LevelNumber",1) < currentLevel + 1){
            PlayerPrefs.SetInt("LevelNumber", currentLevel + 1);
            PlayerPrefs.Save();
        }

        if(currentLevel == maxLevel) {
            LoadLevel("levelSelector");
        } else 
            LoadLevel("Level" + (currentLevel + 1));
    }

    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
    }

    public int Load() {
        return PlayerPrefs.GetInt("LevelNumber", 1);
    }
}
