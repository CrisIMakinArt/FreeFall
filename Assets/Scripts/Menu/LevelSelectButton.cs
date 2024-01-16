using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectButton : MonoBehaviour
{
    public TMP_Dropdown levelSelectDropDown;
    public Popup popup;

    public void ButtonPress()
    {
        string levelName = levelSelectDropDown.options[levelSelectDropDown.value].text;
        if (Application.CanStreamedLevelBeLoaded(levelName))
            SceneManager.LoadScene(levelName);
        else
        {
            popup.AlertPopup("Please Choose a level");
        }
    }

    public void DebugSkipToTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }
}
