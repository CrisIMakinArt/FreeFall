using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using UnityEngine;

public class Platform_Manager : MonoBehaviour
{
    SpriteRenderer sprite;
    Transform platform;
    public Global_Container global_object;
    public string platformType = "Basic";
    // Start is called before the first frame update
    void Start()
    {
        global_object = GetComponent<Global_Container>();
        sprite = GetComponent<SpriteRenderer>();
        platform = GetComponent<Transform>();
        switch (platformType)
        {
            case "Cloud":
                sprite.color = new Color(1, 1, 1, 1);
                break;
            case "Basic":
                sprite.color = new Color(0, 1, 0, 1);
                break;
            case "Horizontal":
                sprite.color = new Color(0, 0, 1, 1);
                break;
            case "Vertical":
                sprite.color = new Color(1, 0, 0, 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (platformType)
        {
            case "Horizontal":
                break;
            case "Vertical":
                break;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (platformType)
            {
                case "Cloud":
                    global_object.stopVelocity();
                    break;
                case "Basic":
                    global_object.Reset();
                    break;
                case "Horizontal":
                    global_object.Reset();
                    break;
                case "Vertical":
                    global_object.Reset();
                    break;
            }
        }


    }

    void OnCollisionExit(Collision other)
    {
        switch (platformType)
        {
            case "Cloud":
                global_object.startVelocity();
                break;
        }

    }

    void Horizontal()
    {
        return;
    }

    void Vertical()
    {
        return;
    }

}

