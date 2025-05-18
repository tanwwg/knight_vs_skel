using UnityEngine;

public class AttackAiState : AiStateBehaviour
{
    public AiStateBehaviour moveBehaviour;

    public ColliderCheck check;
    
    public AnimatorState anim;
    
    public override AiStateBehaviour HandleUpdate()
    {
        if (anim.State == "attack") return this;
        
        if (check.IsOverlap())
        {
            anim.SetState("attack");
            return this;
        }
        else
        {
            return moveBehaviour;
        }
    }
}