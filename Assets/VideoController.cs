using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoPlayer vplayer;
    public AudioSource audioSource;

    void Start() {
        vplayer.loopPointReached += EndReached;
        vplayer.clip = Data.Instance.videoData.selectedClip;
        vplayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        vplayer.controlledAudioTrackCount = 1;
        vplayer.EnableAudioTrack(0, true);
        vplayer.SetTargetAudioSource(0, audioSource);
        StartCoroutine(StartPlaying());
    }

    IEnumerator StartPlaying()
    {
        vplayer.Prepare();
        while (!vplayer.isPrepared)
        {
            yield return new WaitForEndOfFrame();
        }
        vplayer.Play();
    }

    // Update is called once per frame
    void Update() {

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) {
        Data.Instance.scenesManager.Load("Main");
    }

    public void Play() {
        vplayer.Play();        
    }

}
