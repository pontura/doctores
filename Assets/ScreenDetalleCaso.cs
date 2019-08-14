using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDetalleCaso : ScreenBase {
    public override void OnInit() {

    }
    public void LoginPressed() {
        MainEvents.LoadScreen(2, true);
    }

    public void Clicked(int id) {
        string scene = Data.Instance.videoData.SetVideoScene(id);
        MainEvents.ResetAll();
        Data.Instance.scenesManager.Load(scene);
    }

    public void ShowImage(int id) {
        Events.ShowImgPopup(id); 
    }
}    