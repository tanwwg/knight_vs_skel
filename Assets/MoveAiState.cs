using UnityEngine;

public class MoveAiState : AiStateBehaviour
{
    public Transform target;
    public Rigidbody2D body;

    public float speedX;
    
    public AiStateBehaviour attackBehaviour;
    public ColliderCheck attackCheck;
    public AnimatorState anim;
    
    public override AiStateBehaviour HandleUpdate()
    {
        if (attackCheck.IsOverlap())
        {
            body.linearVelocityX = 0f;
            return attackBehaviour;
        }
        
        body.linearVelocityX = Mathf.Sign(target.position.x - body.position.x) * speedX;
        
        
        anim.SetState("run");
        return this;
    }
}
