using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public Rigidbody2D body;
    public Vector2 knockbackScale;

    public UnityEvent<int> onHit;


    public void Hit(WeaponCollider source, Collider2D other)
    {
        if (body)
        {
            var kbX = Mathf.Sign(body.position.x - source.transform.position.x);

            body.AddForce(Vector2.Scale(new Vector2(kbX, 1), knockbackScale) * source.knockback, ForceMode2D.Impulse);
        }
        
        this.onHit.Invoke(source.damage);
        
    }
}
