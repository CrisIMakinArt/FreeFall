using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Stress_UI : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Slider slider;

    public Image sliderFillBody;

    public Color badColor;
    public Color goodColor;

    private float _stress = 0f;
    public float stress
    {
        get
        {
            return _stress * 100f;
        }
        set
        {
            float temp = Mathf.Max(value, 0f);
            temp = Mathf.Min(temp, 100f);
            _stress = temp / 100f;
            updateGraphic();
        }
    }

    private void Start()
    {
        updateGraphic();
    }

    public void updateGraphic()
    {
        slider.value = _stress;
        textMesh.text = Mathf.Round(_stress * 100).ToString() + '%';
        sliderFillBody.color = Color.Lerp(goodColor, badColor, _stress);
    }

}

