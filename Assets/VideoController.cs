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
        
        audioSource.playOnAwake = false;
        vplayer.playOnAwake = false;
        vplayer.isLooping = true;

        vplayer.renderMode = VideoRenderMode.RenderTexture;
        vplayer.aspectRatio = VideoAspectRatio.FitOutside;

        vplayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        vplayer.controlledAudioTrackCount = 1;
        vplayer.EnableAudioTrack(0, true);
        vplayer.SetTargetAudioSource(0, audioSource);
        audioSource.volume = 1f;

        StartCoroutine(PrepareAndPlayVideo());
    }

    IEnumerator PrepareAndPlayVideo()
    {
        vplayer.Prepare();

        while (!vplayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            yield return null;
        }

        Debug.Log("Done prepping.");

        vplayer.Play();
        audioSource.Play();
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
