﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoPlayer vplayer;
    // Start is called before the first frame update
    void Start() {
        //vplayer = GetComponent<VideoPlayer>();
        vplayer.loopPointReached += EndReached;        
    }

    // Update is called once per frame
    void Update() {

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) {
        Data.Instance.scenesManager.Load("Main");
    }

    public void Play() {
        vplayer.Play();
        Debug.Log("aca");
    }

}