using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationStarter : MonoBehaviour {
    void Awake()
    {
        int x = PlayerPrefs.GetInt("firstStart");

        if (x != 1) {
            PlayerPrefs.SetInt("firstStart", 1);
            SceneManager.LoadScene("Level");
        } else {
            SceneManager.LoadScene("LevelSelector");
        }
    }
}
