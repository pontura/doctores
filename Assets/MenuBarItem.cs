using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarItem : MonoBehaviour
{
    public Image image;
    public Text text;    

    public void SetState(bool isOn)
    {
        Color c = Data.Instance.settings.colorDefault;
        if(isOn)
        {
            c = Data.Instance.settings.colorSelected;
        }
        image.color = c;
        text.color = c;
    }
}
