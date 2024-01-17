using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    PlayerMovement player;
    private Rigidbody2D rb;
    bool kill = false;
    float timer = 10;
    int speed = 200;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((transform.forward * speed * Time.deltaTime));
        if (timer < 0)
        {
            kill = true;
        }
        else { timer -= Time.deltaTime; }
        if (kill) { destroyThis(); }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerMovement>();
            player.Reset();
            kill = true;
            
        }


    }

    void destroyThis()
    {
        Destroy(this.gameObject);
    }

}
