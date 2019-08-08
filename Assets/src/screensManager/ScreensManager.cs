﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainEvents
{
    public static System.Action<ButtonStandard> OnButtonClicked = delegate { };
    public static System.Action<string> OnUIFX = delegate { };
    public static System.Action<int, bool> LoadScreen = delegate { };
    public static System.Action ResetAll = delegate { };
    public static System.Action BackScreen = delegate { };
}

public class ScreensManager : MonoBehaviour
{
	public ScreenBase[] all;
    public int initScreenID;
    public ScreenBase activeScreen;
    ScreenBase lastActiveScreen;
    public bool isAdmin;
    public float timeToTransition = 1;
    public bool loading;
    public int id=-1;

    private void Awake()
    {
        MainEvents.LoadScreen += LoadScreen;
        MainEvents.ResetAll += ResetAll;
        MainEvents.BackScreen += BackScreen;
    }
    private void OnDestroy()
    {
        MainEvents.LoadScreen -= LoadScreen;
        MainEvents.ResetAll -= ResetAll;
        MainEvents.BackScreen -= BackScreen;
    }
    void Start()
    {
        int id_ = 0;
        foreach (ScreenBase screenBase in all)
        {
            screenBase.Init(this, id_);
            id_++;
        }
        ResetAll();
        MainEvents.LoadScreen(initScreenID, true);
    }

    void BackScreen() {
        LoadScreen(lastActiveScreen.id, false);
    }

    void LoadScreen(int id, bool isRight)
	{
        Debug.Log("LoadScreen " + id + " loading: " + loading + " activeScreen: " + activeScreen);
        if (this.id == id)
            return;

        this.id = id;
        

        if (loading)
			return;

        MainEvents.OnUIFX("swipe");

		loading = true;
		if (activeScreen != null) {
			activeScreen.SetCenterPosition ();
			activeScreen.MoveTo (isRight, timeToTransition);
			lastActiveScreen = activeScreen;
		}

        activeScreen = all [id];
        activeScreen.gameObject.SetActive (true);
        activeScreen.SetInitialPosition (isRight);
        activeScreen.MoveTo (isRight, timeToTransition);

    }
	public void OnTransitionDone()
	{
        if (!loading)
			return;
		loading = false;
		if (lastActiveScreen != null) {
			lastActiveScreen.gameObject.SetActive (false);
			lastActiveScreen.OnReset ();
		}
		activeScreen.OnInit ();
	}
	public void ResetAll()
	{
        foreach (ScreenBase mainScreen in all) {
			mainScreen.gameObject.SetActive (false);
		}
	}
    void OnApplicationFocus(bool pauseStatus)
    {
        
    }

}
