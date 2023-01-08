using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelButtons;
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
    }
}
