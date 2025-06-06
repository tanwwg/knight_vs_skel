using UnityEngine;

public class AnimatorState : MonoBehaviour
{
    public Animator animator;

    [Header("Read-Only")]
    public string State;

    public bool isDebug;
    
    public void SetState(string newState)
    {
        if (isDebug) Debug.Log("SetState=" + newState);
        // if (!animator.GetCurrentAnimatorStateInfo(0).IsName(newState))
        if (this.State != newState)
        {
            if (isDebug) Debug.Log("AnimatorPlay=" + newState);
            animator.Play(newState);
            this.State = newState;
        }
    }
}
