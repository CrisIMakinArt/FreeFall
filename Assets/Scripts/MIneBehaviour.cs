using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineBehaviour : MonoBehaviour 
{
    private Rigidbody2D body;

    public GameObject player;
    public float speed;
    public float detectionRadius;
    public float explosionDist;

    private bool targeting;

    public void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float playerDist = Vector2.Distance(player.transform.position, transform.position);
        if (playerDist <= detectionRadius)
        {
            targeting = true;
        }
        else 
        {
            targeting = false;
        }
        if (playerDist <= explosionDist) 
        {
            Explode();
        }
    }

    public void FixedUpdate()
    {
        if (targeting) {
            Vector2 force = (player.transform.position - transform.position).normalized;
            force *= speed;
            body.AddForce(force);
        }
    }

    public void Explode() 
    {
        Debug.Log("exploded");
        //cue explosion animation
        //kill player, and self after animation
    }
}