using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float playerVelocity = 0.5f;
    public float TerminalVelocity = 10;
    public float holdVelocity = 0.5f;
    private float lastY;
    public float FallingThreshold = -0.00001f; 
    [HideInInspector]
    private bool Falling = true; //Keep this on True, to prevent issues with certain other things.
    public float Acceleration = 0.05f;
    public float MovementSpeed = 6;
    private Rigidbody2D _rigidbody;
    //------------------------------------------------------------------
    public int testAccell = 0; //test variable
    public int testMovement = 0; //test variable
    public int testTerminal = 1; //test variable


    private void Start()
    {
        lastY = transform.position.y;
        _rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("acceleratePlayer", 0, 0.05f); /*Cris- TLDR. Keep the time ammount >= 0.05f, odd bug, what i think happens is the distancepersecondsincelastframe cannot detect differences
        when they happen more often, so if you lower the time between calls "Aka" set the number from 0.05 to 0.005 or something, the function calls too fast causing distance detection to fail.
        In general this number shouldn't change from 0.05 at all anyway.*/


    }
    void acceleratePlayer() //Accelerates the player, assuming the player is falling
    {
        float distancePerSecondSinceLastFrame = (transform.position.y - lastY) * Time.deltaTime;
        lastY = transform.position.y; 
        if (distancePerSecondSinceLastFrame < FallingThreshold) //Checks if player is falling
        {
            Falling = true;
        }
        else
        {
            Falling = false;
        }

        if (Falling) // if falling - accelerate player by the Acceleration variable
        {
            if (playerVelocity >= TerminalVelocity) //Checks if player is at terminal velocity. If there then set player velocity to terminal. 
                /* Cris- This could cause some issues in the future, I have playerVelocity = TerminalVelocity; as a safeguard for potential bugs.
                 However, if this causes other issues then removing it shouldn't be a problem */
            {
                playerVelocity = TerminalVelocity;
                testTerminal += 1; //test variable
            }
            else
            {
                playerVelocity += Acceleration;
                testAccell += 1; //test variable

            }
            
        }
        else 
        {
            playerVelocity = holdVelocity;
            
            testMovement += 1; // test variable
        }
    }

    private void FixedUpdate() 
    {
        //-----------------------------------------------------------------------------------
        //Left-right movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        _rigidbody.gravityScale = playerVelocity;
        
        //-----------------------------------------------------------------------------------
    }


    public void Reset() //Resets player to orgin.
    {
        transform.position = new Vector3(0, 0, 0);
    }
    
}