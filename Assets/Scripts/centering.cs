using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;

public class centering : MonoBehaviour
{

    Transform parentObject;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = gameObject.transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = parentObject.position.x;
        Vector3 thisPosition = new Vector3(-x * (transform.localScale.x / parentObject.localScale.x), transform.position.y, transform.position.z);
        transform.position = thisPosition;
    }
}
