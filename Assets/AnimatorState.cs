using UnityEngine;

public class AnimatorState : MonoBehaviour
{
    public Animator animator;

    public string State { get; private set; }
    
    public void SetState(string newState)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(newState))
        {
            animator.Play(newState);
            this.State = newState;
        }
    }
}
