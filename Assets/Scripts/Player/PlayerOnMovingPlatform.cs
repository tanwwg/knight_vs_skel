using System;
using UnityEngine;

public class PlayerOnMovingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("moving_platform"))
        {
            this.transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("moving_platform"))
        {
            this.transform.parent = null;
        }
    }
}
