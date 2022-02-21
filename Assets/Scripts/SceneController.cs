using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public int currentLevel = 15;
    int maxLevel = 11;

    static SceneController instance = null;
    
    public static SceneController Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType(typeof(SceneController)) as SceneController;

            return instance;
        }
    }

    void Update() {
            
    }

    public void NextLevel(){
        if(currentLevel == maxLevel) {
            LoadLevel("levelSelector");
        }else

        LoadLevel("Level" + (currentLevel + 1));
    }

    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
    }

    public void Save() {
        PlayerPrefs.SetInt("LevelNumber", currentLevel);
        PlayerPrefs.Save();
    }

    public int Load() {
        return PlayerPrefs.GetInt("LevelNumber", 1);
    }
}
