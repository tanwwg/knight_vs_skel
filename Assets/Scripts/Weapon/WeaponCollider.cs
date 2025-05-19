using System;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public Hittable owner;
    
    public int damage;
    public float knockback;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("WeaponCollider " + other.gameObject.name);
        var hit = other.gameObject.GetComponent<Hittable>();
        if (hit && hit != owner)
        {
            hit.Hit(this, other);
        }
    }
}
