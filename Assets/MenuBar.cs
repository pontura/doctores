using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour
{
    public MenuBarItem[] items;

    public enum types
    {
        INICIO,
        CURSOS,
        PROFESIONALES,
        PERFIL,
        SUBIR
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
            case types.CURSOS:
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
                Select(types.CURSOS);
                MainEvents.LoadScreen(5, true);
                break;
            case 2:
                Select(types.PROFESIONALES);
                MainEvents.LoadScreen(8, true);
                break;
            case 3:
                Select(types.PERFIL);
                MainEvents.LoadScreen(4, true);
                break;
            case 4:
                Select(types.SUBIR);
                MainEvents.LoadScreen(6, true);
                break;
        }
    }
}
