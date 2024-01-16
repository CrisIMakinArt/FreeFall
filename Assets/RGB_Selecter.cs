using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RGB_Selecter : MonoBehaviour
{
    public Slider R_slider;
    public Slider G_slider;
    public Slider B_slider;

    public Image exampleImage;

    float r, g, b;

    void OnDisable()
    {
        PlayerPrefs.SetFloat("R", r);
        PlayerPrefs.SetFloat("G", g);
        PlayerPrefs.SetFloat("B", b);
    }

    void OnEnable()
    {
        r = PlayerPrefs.GetFloat("R");
        g = PlayerPrefs.GetFloat("G");
        b = PlayerPrefs.GetFloat("B");

        R_slider.value = r;
        G_slider.value = g;
        B_slider.value = b;

        exampleImage.color = new Color(r, g, b, 1);
    }


    void Update()
    {
        R_slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        G_slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        B_slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        r = R_slider.value;
        g = G_slider.value;
        b = B_slider.value;
        exampleImage.color = new Color(r, g, b, 1);
    }
}
