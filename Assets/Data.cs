﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Data : MonoBehaviour
{

    const string PREFAB_PATH = "Data";    
    static Data mInstance = null;
    public ScenesManager scenesManager;
    public Settings settings;
    public VideoData videoData;
    public ImageData imageData;

    public int activeScreenId = -1;

    public static Data Instance
	{
		get
		{
			if (mInstance == null)
			{
				mInstance = FindObjectOfType<Data>();

				if (mInstance == null)
				{
					GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
					mInstance = go.GetComponent<Data>();
				}
			}
			return mInstance;
		}
	}
    public void LoadLevel(string aLevelName)
    {
		Debug.Log ("Load Scene " + aLevelName);
        SceneManager.LoadScene(aLevelName);
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
        scenesManager = GetComponent<ScenesManager>();
        settings = GetComponent<Settings>();
        videoData = GetComponent<VideoData>();
        imageData = GetComponent<ImageData>();
    }

}
