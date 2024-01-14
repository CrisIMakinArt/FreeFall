using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Popup : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    float popupTextScale;
    float startTime;
    float alertTime;
    bool alerting;

    private void Start()
    {
        popupTextScale = popupText.transform.localScale.x;
    }

    void Update()
    {
        if (alerting)
        {
            float currentDelay = Time.unscaledTime - startTime;

            float t = currentDelay / alertTime;
            float scale = Mathf.Min(Mathf.Sin(t * Mathf.PI) * 2, 1) -
                          Mathf.Sin(t * Mathf.PI * 6 + Mathf.PI)/20 + 1;

            popupText.transform.localScale = new Vector3(scale, scale, 0);
            if (currentDelay >= alertTime)
            {
                alerting = false;
                popupText.gameObject.SetActive(false);
            }
        }
    }

    public void AlertPopup(string text)
    {
        alerting = true;
        alertTime = 2;

        popupText.gameObject.SetActive(true);
        popupText.text = text;

        startTime = Time.unscaledTime;
        Debug.Log(text);
    }
}
