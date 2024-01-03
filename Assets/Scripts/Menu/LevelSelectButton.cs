using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectButton : MonoBehaviour
{
    public TMP_Dropdown levelSelectDropDown;

    public void ButtonPress()
    {
        string levelName = levelSelectDropDown.options[levelSelectDropDown.value].text;
        try
        {
            SceneManager.LoadScene(levelName);
        }
        catch 
        {
            Debug.Log("invalid Scene name " + levelName);
        }
    }
}
