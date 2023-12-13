using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class Platform_Manager : MonoBehaviour
{
    SpriteRenderer sprite;
    Transform platform;
    PlayerMovement player;
    public string platformType = "Basic";
    // Start is called before the first frame update
    void Start()
    {
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerMovement>();
            switch (platformType)
            {
                
                case "Cloud":
                    break;
                case "Basic":
                    player.Reset();
                    break;
                case "Horizontal":
                    player.Reset();
                    break;
                case "Vertical":
                    player.Reset();
                    break;

            }
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

