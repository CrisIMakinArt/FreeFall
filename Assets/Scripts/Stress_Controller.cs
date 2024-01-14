using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stress_Controller : MonoBehaviour
{
    public Global_Container globalScript;
    public PlayerMovement player;
    string currentPose;

    public Slider stressBar;
    public Image sliderFillArea;
    public Color goodStress;
    public Color badStress;


    public float stressValue = 1f; //Value of stress, idealy will never go over 100 can, however, be negative, for gaemplay reasons

    void Start()
    {
        destress(10); //Odd bug with the stress bar, this fixes it. do not remove
        InvokeRepeating("naturalStressGeneration", 0, 3f); //Calls the natural stress generation function every x amount of seconds. // ("",0,xf)
    }

    void Update ()
    {
        //-----------------------------------------------------------------------------
        //Test Keys. RightShift will stress player while Enter will destress player. Comment out, and change inputs as needed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            destress(10);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            accrueStress(20);
        }
        //------------------------------------------------------------------------------
        
    }
    
    public void accrueStress (float Stress) //Can be called to Stress the player by an ammount given
    {
        stressValue += Stress;
        stressValue = Mathf.Clamp(stressValue, 0, 100);
        stressBar.value = stressValue / 100f;
        sliderFillArea.color = Color.Lerp(goodStress, badStress, stressBar.value);
    }

    public void destress (float Stress) //Can be called to Stress the player by an ammount given
    {
        stressValue -= Stress;
        stressValue = Mathf.Clamp(stressValue, 0, 100);
        stressBar.value = stressValue / 100f;
        sliderFillArea.color = Color.Lerp(goodStress, badStress, stressBar.value);
    }
    void naturalStressGeneration() //Naturally generates stress if player is falling
    {
        float Velocity = player.playerVelocity;
        float minVelocity = player.holdVelocity;
        float maxVelocity = player.TerminalVelocity;
        if (Velocity == minVelocity)
        {
            destress(20);
        }
        else if (Velocity > minVelocity && Velocity < (maxVelocity / 3))
        {
            accrueStress(3);
        }
        else if (Velocity >= (maxVelocity/3) && Velocity < (maxVelocity * (2/3)))
        {
            accrueStress(7);
        }
        else if (Velocity >= (maxVelocity * (2 / 3)) && Velocity < maxVelocity)
        {
            accrueStress(10);
        }
        else if (Velocity == maxVelocity)
        {
            accrueStress(20);
        }

    }
}
