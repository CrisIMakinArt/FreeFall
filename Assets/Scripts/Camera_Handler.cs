using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Camera_Handler : MonoBehaviour
{
    Transform camera_transform;
    public GameObject player;
    Transform playerTransform;
    float y_pos_Player = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera_transform = GetComponent<Transform>();
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 temp_vec = playerTransform.position;    
        y_pos_Player = temp_vec.y;
        camera_transform.position = new Vector3(0, y_pos_Player, 0) + new Vector3(0, -4, -10);
    }
}
