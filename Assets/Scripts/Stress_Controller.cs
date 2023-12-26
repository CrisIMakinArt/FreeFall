using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stress_Controller : MonoBehaviour
{
    public Global_Container globalScript;
    public PlayerMovement player;
    string currentPose;
    public Image stressBar; //Controls the stressBar image

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
        stressValue += Stress * (globalScript.PoseDictGetter())[player.currentPose]["panicModifier"];
        stressValue = Mathf.Clamp(stressValue, 0, 100);
        stressBar.fillAmount = stressValue / 100f;
    }

    public void destress (float Stress) //Can be called to Stress the player by an ammount given
    {
        stressValue -= Stress * (1 / (globalScript.PoseDictGetter())[player.currentPose]["panicModifier"]);
        stressValue = Mathf.Clamp(stressValue, 0, 100);
        stressBar.fillAmount = stressValue / 100f;

    }
    void naturalStressGeneration() //Naturally generates stress if player is falling
    {
        float Velocity = player.playerVelocity;
    
        if (Velocity > 0.5 && Velocity < 5)
        {
            accrueStress(3);
        }
        else if (5 <= Velocity && Velocity <= 7)
        {
            accrueStress(7);
        }
        else if (7 < Velocity && Velocity < 10)
        {
            accrueStress(10);
        }
        else if (Velocity >= 10)
        {
            accrueStress(20);
        }

    }
}
