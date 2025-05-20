using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCheck : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter.Invoke();
    }
    
    
}
