using System;
using UnityEngine;

public static class LayerMaskExtension
{
    public static bool IsInMask(this LayerMask mask, int layer)
    {
        // Check if the object's layer matches the mask using bitwise AND
        return (mask.value & (1 << layer)) != 0;
    }
}

public class WeaponCollider : MonoBehaviour
{
    public Hittable owner;
    public LayerMask hitLayer;
    
    public int damage;
    public float knockback;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hitLayer.IsInMask(other.gameObject.layer)) return;
        
        // Debug.Log("WeaponCollider " + other.gameObject.name);
        var hit = other.gameObject.GetComponent<Hittable>();
        if (hit && hit != owner)
        {
            Debug.Log("WeaponCollider " + other.gameObject.name);
            hit.Hit(this, other);
        }
    }
}
