using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideosVRScreen : MonoBehaviour
{
    public GvrVideoPlayerTexture gvrVideoPlayerTexture;
    public GameObject videoPlayer;

    private void Start()
    {
        UnityEngine.XR.XRSettings.enabled = true;
        // Invoke("Ok", 1);
    }
    void Ok()
    {
        gvrVideoPlayerTexture.ReInitializeVideo();
        //videoPlayer.SetActive(true);
    }
    private void Update()
    {
        // Exit when (X) is tapped.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.XR.XRSettings.enabled = false;
            Data.Instance.LoadLevel("Main");
        }

    }
}
