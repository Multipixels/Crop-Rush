using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake() {
        if(PlayerPrefs.GetFloat("firstAudio") == 0 ) {
            PlayerPrefs.SetFloat("firstAudio", 1);
            ChangeVolume(50);
        } else {
            ChangeVolume(PlayerPrefs.GetFloat("audioVolume"));
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeVolume(float value) {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("audioVolume", value);
    }
}
