using UnityEngine;

public class IdleAiState : AiStateBehaviour
{
    public AiStateBehaviour nextBehaviour;

    public ColliderCheck vision;
    
    public override AiStateBehaviour HandleUpdate()
    {
        if (vision.IsOverlap()) return nextBehaviour;
        return this;
    }
}
