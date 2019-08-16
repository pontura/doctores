using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour
{
    public MenuBarItem[] items;
    public ScreensManager screensManager;

    public enum types
    {
        INICIO,
        PERFIL,
        PUBLICAR,
        MENSAJES,
        RED
    }
    void Start()
    {
        Select(types.INICIO);
    }
    void Select(types type)
    {
        if (screensManager.loading)
            return;

        foreach (MenuBarItem mbi in items)
            mbi.SetState(false);

        switch(type)
        {
            case types.INICIO:
                items[0].SetState(true);
                break;
            case types.PERFIL:
                items[1].SetState(true);
                break;
            case types.PUBLICAR:
                items[2].SetState(true);
                break;
            case types.MENSAJES:
                items[3].SetState(true);
                break;
            case types.RED:
                items[4].SetState(true);
                break;
        }
    }
    public void Clicked(int id)
    {
        if (screensManager.loading)
            return;

        switch (id)
        {
            case 0:
                Select(types.INICIO);
                MainEvents.LoadScreen(2, false);
                break;
            case 1:
                Select(types.PERFIL);
                MainEvents.LoadScreen(4, true);
                break;
            case 2:
                Select(types.PUBLICAR);
                MainEvents.LoadScreen(6, true);
                break;
            case 3:
                Select(types.MENSAJES);
                MainEvents.LoadScreen(5, true);
                break;
            case 4:
                Select(types.RED);
                MainEvents.LoadScreen(7, true);
                break;
        }
    }
}
