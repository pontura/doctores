using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;

public class VideoData : MonoBehaviour    
{

    public List<VideoInfo> videos;
    public VideoClip selectedClip;

    [Serializable]
    public class VideoInfo {
        public VideoClip clip;
        public VideoSceneType scene;
        public int id;
    }

    public enum VideoSceneType {
        Skybox,
        Skybox_2D,
        VideoHD
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string SetVideoScene(int id) {
        VideoData.VideoInfo vinfo = videos.Find(x => x.id == id);
        selectedClip = vinfo.clip;
        return System.Enum.GetName(typeof(VideoData.VideoSceneType), vinfo.scene);
    }
}
