using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        float r = PlayerPrefs.GetFloat("R");
        float g = PlayerPrefs.GetFloat("G");
        float b = PlayerPrefs.GetFloat("B");

        player.GetComponent<SpriteRenderer>().color = new Color(r, g, b);
    }
}
