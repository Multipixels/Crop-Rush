using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{

    public void Start() {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("audioVolume");
    }

    public void ChangeVolume(float value) {
        try {
            SoundManager test = GameObject.Find("MusicManager").GetComponent<SoundManager>();

            test.ChangeVolume(value);
        } catch {; }
    }
}
