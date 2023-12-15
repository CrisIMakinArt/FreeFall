using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float playerVelocity = 1.0f;
    float holdVelocity;
    private float lastY;
    public float FallingThreshold = -0.00001f; 
    [HideInInspector]
    public bool Falling = false;
    public float Acceleration = 0.005f;
    public float MovementSpeed = 6;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        lastY = transform.position.y;
        _rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("acceleratePlayer", 0, 0.0166f);
        holdVelocity = playerVelocity;
    }
    void acceleratePlayer()
    {
        float distancePerSecondSinceLastFrame = (transform.position.y - lastY) * Time.deltaTime;
        lastY = transform.position.y; 
        if (distancePerSecondSinceLastFrame < FallingThreshold)
        {
            Falling = true;
        }
        else
        {
            Falling = false;
        }

        if (Falling)
        {
        playerVelocity += Acceleration;
        }
        else 
        {
            playerVelocity = holdVelocity;
        }
    }

    private void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        _rigidbody.gravityScale = playerVelocity;

    }


    public void Reset()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    
}