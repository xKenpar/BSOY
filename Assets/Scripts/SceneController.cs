using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    [SerializeField] int currentLevel;
    int maxLevel = 5;

    static SceneController instance = null;
    
    public static SceneController Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType(typeof(SceneController)) as SceneController;

            return instance;
        }
    }

    public void NextLevel(){
        if(currentLevel == maxLevel) {
            //Load Menu
        }

        LoadLevel("Level" + (currentLevel + 1));
    }

    void LoadLevel(string name) {
        SceneManager.LoadScene(name);
    }
}
