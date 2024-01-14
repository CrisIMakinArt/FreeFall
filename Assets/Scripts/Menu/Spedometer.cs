using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spedometer : MonoBehaviour
{
    TextMeshProUGUI speedText;
    float startTime;

    void Start()
    {
        startTime = Time.time;
        speedText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        speedText.text = (Mathf.Round((Time.time - startTime) * 10) / 10).ToString();
    }
}
