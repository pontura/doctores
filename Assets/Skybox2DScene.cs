﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Skybox2DScene : MonoBehaviour {
    VideoController vcontroller;
    bool vrenabled;

    // Start is called before the first frame update
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        vcontroller = GetComponent<VideoController>();
        vcontroller.Play();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Back();
        }
    }

    public void Back() {
        Debug.Log("aca");
        Data.Instance.LoadLevel("Main");
    }

}
