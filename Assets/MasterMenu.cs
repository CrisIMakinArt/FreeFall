using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MasterMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject optionsUI;

    bool unpausing = false;
    public int unpausingTime = 30;
    float unpausingStartTime = 0;
    float unpausingNewTime   = 0;
    int currentTimeInt;

    int fontSize = 125;

    public TextMeshProUGUI unpauseText;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuUI.activeSelf)
                Pause();
            else
                Unpause();
        }

        if (unpausing)
        {
            unpausingNewTime += Time.unscaledDeltaTime * 3;
            float currentDelay = unpausingNewTime - unpausingStartTime;

            int displayTime = Mathf.RoundToInt(-(currentDelay - unpausingTime));
            unpauseText.text = displayTime.ToString();

            unpauseText.fontSize = Mathf.Abs(Mathf.Sin(currentDelay * Mathf.PI + 0.5f * Mathf.PI)) * fontSize;

            if (currentDelay >= unpausingTime + .5f)
            {
                unpausing = false;
                unpauseText.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Unpause()
    {
        unpausing = true;
        unpausingStartTime = Time.unscaledTime;
        unpausingNewTime = Time.unscaledTime;
        unpauseText.gameObject.SetActive(true);
        menuUI.SetActive(false);

        currentTimeInt = unpausingTime;
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ButtonLoadMenu()
    {
        Unpause();
        SceneManager.LoadScene("Menu");
    }

    public void LoadOptions()
    {
        optionsUI.SetActive(true);
        menuUI.SetActive(false);
    }

    public void CloseOptions()
    {
        menuUI.SetActive(true);
        optionsUI.SetActive(false);
    }
}
