using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        MainEvents.isLoading += IsLoading;
    }

    void OnDestroy() {
        MainEvents.isLoading -= IsLoading;
    }


    void IsLoading(bool loading) {
        button.interactable = !loading;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
