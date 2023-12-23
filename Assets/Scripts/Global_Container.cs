using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Container : MonoBehaviour
{
    string[] Categories = { "Cannonball", "SwanDive", "SnowAngel", "Recliner", "Pencil" };
    string[] Modifiers = { "accelerationModifier", "horizontalModifier", "strongThreshold", "panicModifier" };
    Dictionary<string, float> Cannonball = new Dictionary<string, float>();
    Dictionary<string, float> SwanDive = new Dictionary<string, float>();
    Dictionary<string, float> SnowAngel = new Dictionary<string, float>();
    Dictionary<string, float> Recliner = new Dictionary<string, float>();
    Dictionary<string, float> Pencil = new Dictionary<string, float>();
    Dictionary<string, Dictionary<string, float>> Pose_Dict = new Dictionary<string, Dictionary<string, float>>();
    // Start is called before the first frame update
    void Start()
    {
        Cannonball.Add(Modifiers[0], 1.2f);
        Cannonball.Add(Modifiers[1], .4f);
        Cannonball.Add(Modifiers[2], .1f);
        Cannonball.Add(Modifiers[3], .8f);

        SwanDive.Add(Modifiers[0], 1.5f);
        SwanDive.Add(Modifiers[1], .65f);
        SwanDive.Add(Modifiers[2], .15f);
        SwanDive.Add(Modifiers[3], 1.5f);

        SnowAngel.Add(Modifiers[0], .5f);
        SnowAngel.Add(Modifiers[1], 1.4f);
        SnowAngel.Add(Modifiers[2], .5f);
        SnowAngel.Add(Modifiers[3], 1.2f);

        Recliner.Add(Modifiers[0], .75f);
        Recliner.Add(Modifiers[1], 1.25f);
        Recliner.Add(Modifiers[2], .4f);
        Recliner.Add(Modifiers[3], .5f);

        Pencil.Add(Modifiers[0], 1f);
        Pencil.Add(Modifiers[1], 1f);
        Pencil.Add(Modifiers[2], .35f);
        Pencil.Add(Modifiers[3], 1f);

        Pose_Dict.Add(Categories[0], Cannonball);
        Pose_Dict.Add(Categories[1], SwanDive);
        Pose_Dict.Add(Categories[2], SnowAngel);
        Pose_Dict.Add(Categories[3], Recliner);
        Pose_Dict.Add(Categories[4], Pencil);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Dictionary<string, Dictionary<string, float>> PoseDictGetter()
    {
        return Pose_Dict;
    }
}
