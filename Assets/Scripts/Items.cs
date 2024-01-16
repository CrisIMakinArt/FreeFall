using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public string CurrentItem = "Stopwatch";
    //---------------------------------------------
    //Stopwatch variables
    public float TimeScale;
    private float StartTimeScale;
    private float StartFixedDeltaTime;

    //---------------------------------------------
    public int test = 0;

    // Update is called once per frame
    void Start()
    {
        StartTimeScale = Time.timeScale;
        StartFixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        InputSelector();
    }
    void InputSelector ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentItem == "Stopwatch")
            {
                StartWatch();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (CurrentItem == "Stopwatch")
            {
                StopWatch();
            }
        }
    }
    //-----------------------------------------------------
    //StopWatch
    public void StartWatch()
    {
        Time.timeScale = TimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime * TimeScale;
    }
    public void StopWatch ()
    {
        Time.timeScale = StartTimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime;
    }
    //------------------------------------------------------
}
