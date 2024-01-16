using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelecter : MonoBehaviour
{
    void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            string sceneName = SceneUtility.GetScenePathByBuildIndex(i);
            if (!sceneName.Contains("Scene"))
                continue;
            scenes[i] = sceneName;
            Debug.Log(sceneName);
        }
    }
}
