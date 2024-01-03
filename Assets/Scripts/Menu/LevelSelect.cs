using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour
{
    private void Start()
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (SceneManager.GetActiveScene().name == "TestScene")
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                SceneManager.LoadScene("TestScene");
            }
        }
    }
}
