using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSplash : ScreenBase
{
    public override void OnInit()
    {
        print("init");
        Invoke("Done", 3);
    }
    void Done()
    {
        MainEvents.LoadScreen(1,true);
    }


}
