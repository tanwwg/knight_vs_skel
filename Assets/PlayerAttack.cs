using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Read Only")]
    public bool isAttacking;

    public void EndAttack()
    {
        isAttacking = false;
    }
    
    
}
