using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

    public void LoadLevelRush() {
        try {
            SceneManager.LoadScene("LevelRush");
        } catch {
            ;
        }
    }

    public void ReloadLevel() {
        try {
            if (PlayerPrefs.GetInt("currentLevel") == -1) {
                SceneManager.LoadScene("LevelRush");
            } else {
                SceneManager.LoadScene("Level");
            }
        } catch {
            ;
        }
    }

    public void LoadLevel(int lvl) {
        PlayerPrefs.SetInt("currentLevel", lvl);
        try {
            SceneManager.LoadScene("Level");
        } catch {
            ;
        }
    }

    public void LoadNextLevel() {
        MapManager x = GameObject.Find("MapManager").GetComponent<MapManager>();
        int lvl = x.level;
        PlayerPrefs.SetInt("currentLevel", lvl+1);

        if (lvl == 9) {
            LoadLevelSelect();
            return;
        }

        try {
            SceneManager.LoadScene("Level");
        } catch {
            ;
        }
    }

    public void LoadLevelSelect() {
        SceneManager.LoadScene("LevelSelector");
    }

    public void Quit() {
        Application.Quit();
    }
}
