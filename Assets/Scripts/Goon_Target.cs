using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_Target : MonoBehaviour
{
    public GameObject player;
    private Transform player_transform;
    // Start is called before the first frame update
    void Start()
    {
        player_transform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = player_transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
