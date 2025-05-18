using System;
using UnityEngine;
using UnityEngine.Events;

public enum AiState
{
    Idle, Move, Attack
}

public class Enemy : MonoBehaviour
{
    public UnityEvent onDie;

    public AiStateBehaviour aiState;

    private void FixedUpdate()
    {
        aiState = aiState.HandleUpdate();
    }
}
