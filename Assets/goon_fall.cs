
using System.Collections.Generic;
using UnityEngine;

public class goon_fall : MonoBehaviour
{
    
    float speed = -.2f;
    float random_sway;

    void Update()
    {
        random_sway = Random.Range(-.8f, .8f);
        transform.Translate((transform.up * speed * Time.deltaTime));
        transform.Translate((transform.forward * random_sway * Time.deltaTime));
    }
}

