using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCasos : ScreenBase
{
    public override void OnInit()
    {

    }
    public void LoginPressed()
    {
        MainEvents.LoadScreen(2, true);
    }
    public void Clicked(int id)
    {
        Data.Instance.scenesManager.Load("VRVideos");
    }

}