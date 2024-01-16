using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHit : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Platform"))
            return;

        if (collision.gameObject.TryGetComponent<Platform_Manager>(out Platform_Manager platform_manager))
        {
            if (platform_manager.breakable)
                Destroy(collision.gameObject);
        }
        else
        {
            playerMovement.Reset();
        }
    }
}
