using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    static UI mInstance = null;
    public ScreensManager screensManager;

    public static UI Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<UI>();
            }
            return mInstance;
        }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        screensManager = GetComponent<ScreensManager>();
    }
}
