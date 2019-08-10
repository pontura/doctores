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
        if (id == -1) {
            MainEvents.ResetAll();
            Data.Instance.scenesManager.Load("Skybox");        
        } else if (id == -2) {
            MainEvents.ResetAll();
            Data.Instance.scenesManager.Load("Skybox_2D");
        } else if (id == -3) {
            MainEvents.ResetAll();
            Data.Instance.scenesManager.Load("VideoHD");
        } else {
            MainEvents.LoadScreen(id, true);            
        }
    }

}