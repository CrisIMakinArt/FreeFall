using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Camera_Handler : MonoBehaviour
{
    Transform camera_transform;
    public PlayerMovement player;
    float y_pos_Player = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera_transform = GetComponent<Transform>();
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 temp = player.transform.position;
        y_pos_Player = temp.y;
        camera_transform.position = new Vector3(0, y_pos_Player, 0) + new Vector3(0, -4, 0);
    }
}
