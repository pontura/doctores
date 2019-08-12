using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainEvents
{
    public static System.Action<ButtonStandard> OnButtonClicked = delegate { };
    public static System.Action<string> OnUIFX = delegate { };
    public static System.Action<int, bool> LoadScreen = delegate { };
    public static System.Action ResetAll = delegate { };
    public static System.Action BackScreen = delegate { };
    public static System.Action<bool> ShowMenuBar = delegate { };
    public static System.Action<bool> isLoading = delegate { };
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
    public MenuBar menubar;

    private void Awake()
    {
        MainEvents.LoadScreen += LoadScreen;
        MainEvents.ResetAll += ResetAll;
        MainEvents.BackScreen += BackScreen;
        MainEvents.ShowMenuBar += ShowMenuBar;
    }
    private void OnDestroy()
    {
        MainEvents.LoadScreen -= LoadScreen;
        MainEvents.ResetAll -= ResetAll;
        MainEvents.BackScreen -= BackScreen;
        MainEvents.ShowMenuBar -= ShowMenuBar;
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
        if (Data.Instance.activeScreenId > -1) {
            MainEvents.LoadScreen(Data.Instance.activeScreenId, true);
            ShowMenuBar(true);
        } else {
            MainEvents.LoadScreen(initScreenID, true);
        }

    }

    void ShowMenuBar(bool enable) {
        menubar.gameObject.SetActive(enable);
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
        MainEvents.isLoading(true);
		if (activeScreen != null) {
			activeScreen.SetCenterPosition ();
			activeScreen.MoveTo (isRight, timeToTransition);
			lastActiveScreen = activeScreen;
            
        }

        Data.Instance.activeScreenId = id;
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
        MainEvents.isLoading(false);
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
