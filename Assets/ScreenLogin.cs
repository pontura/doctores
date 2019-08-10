using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLogin : ScreenBase
{
    public override void OnInit()
    {

    }
    public void LoginPressed()
    {
        MainEvents.LoadScreen(2, true);
        MainEvents.ShowMenuBar(true);
    }

}