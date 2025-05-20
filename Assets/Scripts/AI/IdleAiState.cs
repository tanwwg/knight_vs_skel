using UnityEngine;
using UnityEngine.Events;

public class IdleAiState : AiStateBehaviour
{
    public AiStateBehaviour nextBehaviour;
    public UnityEvent onMove;

    public AnimatorState animState;
    public ColliderCheck vision;
    
    public override AiStateBehaviour HandleUpdate()
    {
        animState.SetState("idle");
        if (vision.IsOverlap())
        {
            onMove.Invoke();
            return nextBehaviour;
        }
        return this;
    }
}
