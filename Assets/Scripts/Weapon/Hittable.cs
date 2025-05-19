using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public int health;

    public Rigidbody2D body;
    public Vector2 knockbackScale;

    public UnityEvent<int> onHit;
    public UnityEvent onDie;
    
    public void Hit(WeaponCollider source, Collider2D other)
    {
        // don't process if already dead
        if (health <= 0) return;
        
        if (body)
        {
            var kbX = Mathf.Sign(body.position.x - source.transform.position.x);

            body.AddForce(Vector2.Scale(new Vector2(kbX, 1), knockbackScale) * source.knockback, ForceMode2D.Impulse);
        }
        
        this.onHit.Invoke(source.damage);

        health -= source.damage;
        if (health <= 0)
        {
            onDie.Invoke();
        }

    }
}
