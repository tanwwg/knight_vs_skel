using UnityEngine;

public class MoveAiState : AiStateBehaviour
{
    public Transform myTransform;
    
    public Transform target;
    public Rigidbody2D body;

    public float speedX;

    public AiStateBehaviour idleBehaviour;
    public ColliderCheck idleCheck;
    
    public AiStateBehaviour attackBehaviour;
    public ColliderCheck attackCheck;
    
    public AnimatorState anim;
    
    public override AiStateBehaviour HandleUpdate()
    {
        if (!idleCheck.IsOverlap()) return idleBehaviour;
        
        if (attackCheck.IsOverlap())
        {
            body.linearVelocityX = 0f;
            return attackBehaviour;
        }
        
        body.linearVelocityX = Mathf.Sign(target.position.x - body.position.x) * speedX;
        myTransform.localScale = new Vector3(Mathf.Sign(body.linearVelocityX), 1, 1);
        
        anim.SetState("run");
        return this;
    }
}
