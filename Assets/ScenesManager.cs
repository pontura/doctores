using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public void Load(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
