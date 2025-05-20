using System;
using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public int maxHealth;
    
    public Rigidbody2D body;
    public Vector2 knockbackScale;

    public UnityEvent<float> onHealthUpdate;
    public UnityEvent<int> onHit;
    public UnityEvent onDie;

    [Header("Read-Only")]
    public int health;

    private void Awake()
    {
        health = maxHealth;
        onHealthUpdate.Invoke(health / (float)maxHealth);
    }

    public void Hit(WeaponCollider source, Collider2D other)
    {
        // don't process if already dead
        if (health <= 0) return;
        
        if (body)
        {
            var srcTransform = other.transform;
            if (source.owner) srcTransform = source.owner.transform;
            var kbX = Mathf.Sign(body.position.x - srcTransform.position.x);

            body.AddForce(Vector2.Scale(new Vector2(kbX, 1), knockbackScale) * source.knockback, ForceMode2D.Impulse);
        }
        
        this.onHit.Invoke(source.damage);

        health = Mathf.Max(0, health - source.damage);
        onHealthUpdate.Invoke(health / (float)maxHealth);
        if (health <= 0)
        {
            onDie.Invoke();
        }

    }
}
