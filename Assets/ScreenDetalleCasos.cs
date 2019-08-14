using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDetalleCasos : ScreenBase {

    public GameObject PERFILES;
    public GameObject CANALES;

    public types type;
    public enum types
    {
        PERFILES,
        CANALES
    }
    private void Start()
    {
        type = types.CANALES;
        Switch();
    }
    public void Switch()
    {
        PERFILES.SetActive(false);
        CANALES.SetActive(false);

        if (type == types.PERFILES)
            type = types.CANALES;
        else
            type = types.PERFILES;

        switch(type)
        {
            case types.PERFILES:
                PERFILES.SetActive(true);
                break;
            case types.CANALES:
                CANALES.SetActive(true);
                break;
        }
    }
    public override void OnInit() {

    }
    public void LoginPressed() {
        MainEvents.LoadScreen(2, true);
    }
    public void Clicked(int id) {       
       MainEvents.LoadScreen(id, true);       
    }

}