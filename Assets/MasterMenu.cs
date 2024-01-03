using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterMenu : MonoBehaviour
{
    public GameObject menuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuUI.SetActive(!menuUI.activeSelf);
        }
    }

    public void ButtonLoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
