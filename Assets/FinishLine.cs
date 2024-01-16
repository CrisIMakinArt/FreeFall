using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public MasterMenu masterMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        masterMenu.endScreenUI.SetActive(true);

        if (masterMenu.menuUI.activeSelf)
            masterMenu.menuUI.SetActive(false);
        if (masterMenu.optionsUI.activeSelf)
            masterMenu.optionsUI.SetActive(false);

        Time.timeScale = 0.2f;
    }
}
