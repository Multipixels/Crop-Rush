using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonAppearance : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        #if UNITY_WEBGL
            gameObject.SetActive(false);
        #endif

    }
}
