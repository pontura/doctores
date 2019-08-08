using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDetalleCasos : ScreenBase {
    public override void OnInit() {

    }
    public void LoginPressed() {
        MainEvents.LoadScreen(2, true);
    }
    public void Clicked(int id) {       
       MainEvents.LoadScreen(id, true);       
    }

}