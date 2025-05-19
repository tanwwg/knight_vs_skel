using UnityEngine;

public class IdleAiState : AiStateBehaviour
{
    public AiStateBehaviour nextBehaviour;

    public AnimatorState animState;
    public ColliderCheck vision;
    
    public override AiStateBehaviour HandleUpdate()
    {
        animState.SetState("idle");
        if (vision.IsOverlap()) return nextBehaviour;
        return this;
    }
}
