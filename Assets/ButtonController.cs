using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        MainEvents.isLoading += IsLoading;
    }
    void OnDestroy() {
        MainEvents.isLoading -= IsLoading;
    }
    void IsLoading(bool loading) {
       // button.interactable = !loading;
    }
}
