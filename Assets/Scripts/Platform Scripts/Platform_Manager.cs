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
    int kill = 0;
    public int distance = 5;
    public int direction = 1;
    public int speed = 1;
    public Vector3 start_position;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        platform = GetComponent<Transform>();
        start_position = platform.position;
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
            case "Weak":
                sprite.color = new Color(1, 1, 0, 1);
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (platformType)
        {
            case "Horizontal":
                movement(new Vector3(1, 0, 0));
                break;
            case "Vertical":
                movement(new Vector3(0, 1, 0));
                break;
        }
        if (kill == 1) {
            destroyThis();
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
                case "Weak":
                    if (player.strong)
                    {
                        kill = 1;
                    }
                    else { player.Reset(); }
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

    void destroyThis()
    {
        Destroy(this.gameObject);
    }

    void movement(Vector3 vec3)
    {
        Vector3 current_position = platform.position;
        if (Vector3.Distance(current_position, start_position) > distance)
        {
            direction *= -1;
        }
        platform.position += vec3 * direction * speed / 60;
    }

}

