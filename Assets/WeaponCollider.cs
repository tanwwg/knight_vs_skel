using System;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger " + other.gameObject.name);

        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.onDie.Invoke();
        }
    }
}
