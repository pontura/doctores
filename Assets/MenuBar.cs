using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour
{
    public MenuBarItem[] items;

    public enum types
    {
        INICIO,
        CASOS,
        PROFESIONALES,
        PERFIL
    }
    void Start()
    {
        Select(types.INICIO);
    }
    void Select(types type)
    {
        foreach (MenuBarItem mbi in items)
            mbi.SetState(false);

        switch(type)
        {
            case types.INICIO:
                items[0].SetState(true);
                break;
            case types.CASOS:
                items[1].SetState(true);
                break;
            case types.PROFESIONALES:
                items[2].SetState(true);
                break;
            case types.PERFIL:
                items[3].SetState(true);
                break;
        }
    }
    public void Clicked(int id)
    {
        switch(id)
        {
            case 0:
                Select(types.INICIO);
                MainEvents.LoadScreen(2, false);
                break;
            case 1:
                Select(types.CASOS);
                MainEvents.LoadScreen(3, true);
                break;
            case 2:
                Select(types.PROFESIONALES);
                break;
            case 3:
                Select(types.PERFIL);
                break;
        }
    }
}
