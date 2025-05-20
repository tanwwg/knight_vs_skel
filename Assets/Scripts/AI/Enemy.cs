using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AiStateBehaviour aiState;

    private void FixedUpdate()
    {
        aiState = aiState.HandleUpdate();
    }
}
