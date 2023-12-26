using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Velocity_UI : MonoBehaviour
{
    public TextMeshProUGUI velocityText;

    private float _velocity = 0;
    public float velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = value;
            updateGraphic();
        }
    }

    void Start()
    {

        updateGraphic();        

    }

    public void updateGraphic()
    {
        velocityText.text = (Mathf.Round(velocity * 100)).ToString() + " mph";
    }

}

