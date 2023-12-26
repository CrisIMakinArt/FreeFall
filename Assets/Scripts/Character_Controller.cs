using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    /* -------------UI----------------- 

    public Stress_UI stress_UI;
    public Velocity_UI velocity_UI;

    -------------UI----------------- */


    public float playerVelocity = 0.5f;
    public float TerminalVelocity = 500;
    public float holdVelocity = 0.5f;
    private float lastY;
    public float FallingThreshold = -0.00001f;
    [HideInInspector]
    public bool Falling = true; //Keep this on True, to prevent issues with certain other things.
    public float Acceleration = 20f;
    public float MovementSpeed = 6f;
    private Rigidbody2D _rigidbody;
    //------------------------------------------------------------------
    public int testAccell = 0; //test variable
    public int testMovement = 0; //test variable
    public int testTerminal = 0;

    public GameObject outline;

    SpriteRenderer sprite;
    SpriteRenderer outlineSprite;
    public string currentPose = "Pencil";

    public float velocityPercent = 0;
    public bool strong = false;
    public Global_Container globalScript;
    public string[] poses = { "Pencil", "Cannonball" };
    int pose_place = 0;

    private void Start()
    {
        lastY = transform.position.y;
        _rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("acceleratePlayer", 0, 0.05f); /*Cris- TLDR. Keep the time ammount >= 0.05f, odd bug, what i think happens is the distancepersecondsincelastframe cannot detect differences
        when they happen more often, so if you lower the time between calls "Aka" set the number from 0.05 to 0.005 or something, the function calls too fast causing distance detection to fail.
        In general this number shouldn't change from 0.05 at all anyway.*/
        sprite = GetComponent<SpriteRenderer>();
        outlineSprite = outline.GetComponent<SpriteRenderer>();
        currentPose = poses[pose_place];
        PoseAnimation();
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
                playerVelocity += Acceleration * (globalScript.PoseDictGetter())[currentPose]["accelerationModifier"];
                testAccell += 1; //test variable

            }


        }
        else
        {
            playerVelocity = holdVelocity;
            testMovement += 1; // test variable
        }
        velocityPercent = playerVelocity / TerminalVelocity;

    }

    private void FixedUpdate()
    {
        if (strong != StrongCheck()) { strong = StrongCheck(); }

        //-------------------------------Left-right movement----------------------------------------------
        var movement = Input.GetAxis("Horizontal") * (globalScript.PoseDictGetter())[currentPose]["horizontalModifier"];
        _rigidbody.velocity = new Vector2(movement * MovementSpeed, _rigidbody.velocity.y);
        _rigidbody.gravityScale = playerVelocity;

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Min(-_rigidbody.velocity.y, TerminalVelocity));
        //-------------------------------Left-right movement----------------------------------------------


        //---------------------UI-------------------------------
        //velocity_UI.velocity = -_rigidbody.velocity.y;
        //---------------------UI-------------------------------
    }

    public void PoseChange(InputAction.CallbackContext context)
    {
        switch (pose_place)
        {
            case 0: pose_place = 1; break;
            case 1: pose_place = 0; break;

        }
        currentPose = poses[pose_place];
        PoseAnimation();
    }

    public void PoseAnimation()
    {
        switch (currentPose)
        {
            case "Pencil":
                sprite.color = new Color(.8f, 1, 0, 1);
                break;
            case "Cannonball":
                sprite.color = new Color(0, 0, 0, 1);
                break;
            case "SwanDive":
                sprite.color = new Color(1, 0, 1, 1);
                break;
            case "Recliner":
                sprite.color = new Color(.8f, 1, .2f, 1);
                break;
            case "SnowAngel":
                sprite.color = new Color(1, 1, 1, 1);
                break;
        }
    }

    private bool StrongCheck()
    {
        if (velocityPercent > (globalScript.PoseDictGetter())[currentPose]["strongThreshold"])
        {
            outlineSprite.color = new Color(.32f, .25f, .25f, 1);
            return true;
        }
        else
        {
            outlineSprite.color = new Color(.32f, .25f, .25f, 0);
            return false;
        }
    }

    public void Reset() //Resets player to orgin.
    {
        transform.position = new Vector3(0, 0, 0);
    }

    //-----------------------------------------------------------
    // Getters and setters

    public bool GetFalling() //Probably unneeded
    {
        return Falling;
    }
    public float GetVelocity()
    {
        return playerVelocity;
    }
    public void SetVelocity(float velocity)
    {
        playerVelocity = velocity;
    }
    public void SetAcceleration(float acceleration)
    {
        Acceleration = acceleration;
    }
}