using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimiter : MonoBehaviour {

    [SerializeField] private int frameRate = 120;
    void Start() {
        // Make the game run as fast as possible
        // QualitySettings.vSyncCount = 10;
        Application.targetFrameRate = frameRate;

        Debug.Log("Application Famerate Limited to " + Application.targetFrameRate);
    }
}

