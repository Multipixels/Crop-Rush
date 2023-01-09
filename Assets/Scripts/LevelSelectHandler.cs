using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelButtons;

    [SerializeField]
    private GameObject levelRushButton;

    void Start()
    {
        for (int i = 1; i < 10; i++) {
            int x = PlayerPrefs.GetInt($"{i-1}Stars");
            //Debug.Log(x);
            if (x == 0) {
                levelButtons[i].SetActive(false);
            }
        }

        for (int i = 0; i < 10; i++) {
            int x = PlayerPrefs.GetInt($"{i}Stars");
            if (x >= 1) {
                levelButtons[i].transform.Find("Star1").gameObject.SetActive(true);
            }

            if (x >= 2) {
                levelButtons[i].transform.Find("Star2").gameObject.SetActive(true);
            }

            if (x >= 3) {
                levelButtons[i].transform.Find("Star3").gameObject.SetActive(true);
            }
        }

        int y = PlayerPrefs.GetInt($"9Stars");
        if(y == 0) {
            levelRushButton.SetActive(false);
        }

        int z = PlayerPrefs.GetInt($"rushStars");
        if (z >= 1) {
            levelRushButton.transform.Find("Star1").gameObject.SetActive(true);
        }

        if (z >= 2) {
            levelRushButton.transform.Find("Star2").gameObject.SetActive(true);
        }

        if (z >= 3) {
            levelRushButton.transform.Find("Star3").gameObject.SetActive(true);
        }

    }
}
