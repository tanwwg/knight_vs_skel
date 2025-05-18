using UnityEngine;

public class ColliderCheck: MonoBehaviour
{
    public Collider2D check;
    public LayerMask checkLayers;

    public bool IsOverlap()
    {
        return check.IsTouchingLayers(checkLayers.value);
    }

}