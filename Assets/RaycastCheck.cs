using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    public Vector2 direction;
    public float distance;
    public LayerMask layer;
    
    public bool IsHit()
    {
        return Physics2D.Raycast(transform.position, direction, distance, layer.value);
    }
}
