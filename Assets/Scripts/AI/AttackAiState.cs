using UnityEngine;

public class AttackAiState : AiStateBehaviour
{
    public AiStateBehaviour moveBehaviour;

    public ColliderCheck check;

    public Cooldown attackCooldown;
    
    public override AiStateBehaviour HandleUpdate()
    {
        if (attackCooldown.isActivated) return this;
        
        if (check.IsOverlap())
        {
            Debug.Log("Attack!");
            attackCooldown.Activate();
            return this;
        }
        else
        {
            return moveBehaviour;
        }
    }
}