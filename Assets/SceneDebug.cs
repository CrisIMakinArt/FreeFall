using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDebug : MonoBehaviour
{
    void Start()
    {
        // SceneManager.GetAllScenes() is obsolete ig
        int activeSceneNum = SceneManager.sceneCount;
        for (int i = 0; i < activeSceneNum; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != "Menu")
            {
                SceneManager.UnloadSceneAsync(scene.name);
            }
        }
    }

}
