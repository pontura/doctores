using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SkyboxScene : MonoBehaviour
{
    VideoController vcontroller;
    bool vrenabled;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        vcontroller = GetComponent<VideoController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!vrenabled) {
            StartCoroutine(SwitchToVR());
            vrenabled = true;
            vcontroller.Play();
        }
    }

    IEnumerator SwitchToVR() {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard"; // Or "cardboard"."daydream"

        // Some VR Devices do not support reloading when already active, see
        // https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
        if (string.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0) {
            XRSettings.LoadDeviceByName(desiredDevice);

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;
        }

        // Now it's ok to enable VR mode.
        XRSettings.enabled = true;
    }
}
